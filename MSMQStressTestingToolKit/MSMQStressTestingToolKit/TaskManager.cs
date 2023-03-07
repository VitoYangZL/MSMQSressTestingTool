using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Messaging;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace MSMQStressTestingToolKit
{
    public class TaskManager
    {
        public int MessageAmount { get; set; }
        public int QueueAmount { get; set; }

        ConcurrentBag<DateTime> AllMessageTime = new ConcurrentBag<DateTime>(); //每則訊息傳送的時間點
        ConcurrentBag<DateTime> AllQueueTime = new ConcurrentBag<DateTime>(); //每條訊息佇列完成傳送的時間點 
        ConcurrentBag<int> CpuUsage = new ConcurrentBag<int>(); 
        ConcurrentBag<int> RamUsage = new ConcurrentBag<int>();

        DateTime FirstProcessTime = new DateTime();//程式開始執行的時間點 => 計算一次
        DateTime EndProcessTime = new DateTime();//處理完所有報表數據可以往下包裝的時間點 => 計算一次
        DateTime FirstQueueTime = new DateTime();//第一條訊息佇列開始執行的時間點 => 計算一次
        DateTime EndQueueTime = new DateTime();//最後一條訊息佇列執行完成的時間點 => 計算一次

        TimeSpan SumMessageTime = new TimeSpan();//所有訊息耗用的傳送時間
        int AvgMessageTime = 0; //平均每則訊息的傳送時間 (ms)
        DateTime MaxDatetime = new DateTime(); //本輪測試中所有訊息中最晚的時間
        DateTime MinDatetime = new DateTime(); //本輪測試中所有訊息中最早的時間
        
        int MaxCpuUsage = 0;
        int MinCpuUsage = 0;
        int MaxRamUsage = 0;
        int MinRamUsage = 0;

        //controller and flag

        int Counter = 0;
        bool isFirstQueue = true;
        bool isFirstProcess = true;

        public bool endTesting = false;

        //

        public ReportCell rc = new ReportCell();

        /*
         *報表產生與測試作業放在一起以便將關鍵資料寫入而不用過度傳遞
         *
         *有一種工具RDLC 要研究一下 (ERP報表設計 常用工具) 
         * 
         * 閱讀一些ERP 以及 報表 的研究文章及設計原則
         * 
         * >時間差測試
         * 
         * 1.每則訊息的平均時間 => 每則需要送出前後計時
         * 2.每條Queue的完成平均時間 => 每條需要完成前後計時並使用旗標決定是否完成
         * 3.總耗用時間 => 從第一條Queue的第一則訊息 以及 最後一條Queue的最後一則訊息 的計時而決定
         * 4.峰值CPU 
         * 5.平均CPU
         * 6.峰值RAM
         * 7.平均RAM
         * 
         * 目標 : 餵一個 ConcurrenDict 就能產生 一種 規格 的報表
         *
         */
        public void InitialTaskManagerVariable() 
        {
            MessageAmount = 0;
            QueueAmount = 0;
            AllMessageTime = new ConcurrentBag<DateTime>();
            AllQueueTime = new ConcurrentBag<DateTime>();
            CpuUsage = new ConcurrentBag<int>();
            RamUsage = new ConcurrentBag<int>();

            FirstProcessTime = new DateTime();
            EndProcessTime = new DateTime();
            FirstQueueTime = new DateTime();
            EndQueueTime = new DateTime();

            DateTime SumCostTime = new DateTime();
            DateTime AvgMessageTime = new DateTime();
            DateTime MaxDatetime = new DateTime();
            DateTime MinxDatetime = new DateTime();

            MaxCpuUsage = 0;
            MinCpuUsage = 0;
            MaxRamUsage = 0;
            MinRamUsage = 0;

            Counter = 0;
            isFirstQueue = true;
            isFirstProcess = true;

        }



        #region TimeGap Testing
        public ReportCell StartTesting_TimeGap(MessageQueueManager qm  ,string str)
        {
            MessageAmount = qm.CurrentTextAmount;
            QueueAmount = qm.CurrentMessageQueueAmount;

            /*從這裡以下開始確認執行測試，故應該鎖定UI使用並等待所有測試及報表完成*/
            if (isFirstProcess)
            {
                FirstProcessTime = DateTime.Now;   //程式開始執行的時間點
                isFirstProcess = false;
            }
            for (var i = 0; i < qm.CurrentMessageQueueAmount; i++)
            {
                Thread newThread = new Thread(Execution_TimeGap);
                newThread.IsBackground = true;
                string id = "mq" + i.ToString();
                MessageQueueUnit Target;
                qm.DictMessageQueueUnit.TryGetValue(id, out Target);
                Target.Message = str;
                newThread.Start(Target);
            }
            return rc;
        }

        private void Execution_TimeGap(object mq )
        {
            var tmp = (MessageQueueUnit)mq;
            MessageQueue messageQueue = tmp.MQ;
            if (isFirstQueue)
            {
                FirstQueueTime = DateTime.Now; //第一條Queue開始執行的時間點
                isFirstQueue = false;
            }
            for (var j = 0; j < MessageAmount; j++)
            {
                AllMessageTime.Add(DateTime.Now); //所有訊息的傳送時間點
                messageQueue.Send(tmp.Message);
            }
            AllQueueTime.Add(DateTime.Now); //每條Queue完成執行的時間點
            StatusChecking_TimeGap();



        }
        #endregion
        public void StatusChecking_TimeGap()
        {
            Counter++;
            if (Counter == QueueAmount)
            {
                rc.Name = "timegap";
                bool initFlag = true;
                EndQueueTime = DateTime.Now;
                DateTime QueueCostTime = new DateTime();
                DateTime max = new DateTime();
                DateTime min = new DateTime();
                min = DateTime.Now;
                //如果計數器的數量與Queue數量相同等於已經完成傳送 也等於 這是最後一個Queue
                //所以已經可以開始打包報表數據 以及 這邊要記錄 最後一個Queue的時間點

                #region Max&MinDateTime
                foreach(DateTime dt in AllMessageTime)
                {
                    if(dt > max)
                    {
                        max = dt;
                    }
                }
                MaxDatetime = max;
                foreach(DateTime dt in AllMessageTime)
                {
                    if(dt < min)
                    {
                        min = dt;
                    }
                }
                MinDatetime = min;
                #endregion
                #region SumMessageTime

                TimeSpan ts = new TimeSpan();
                ts = max - min;
                SumMessageTime = ts;
                #endregion
                #region AvgMessageTime

                AvgMessageTime = (SumMessageTime.Milliseconds) / MessageAmount;
                #endregion
                #region SumQueueTime


                #endregion


                #region EndProcessTime(這個一定要最後)
                EndProcessTime = DateTime.Now;
                #endregion

                //打包報表數據

                try
                {
                    rc.AllMessageTime = AllMessageTime;
                    rc.AllQueueTime = AllQueueTime;
                    //rc.CpuUsage = CpuUsage;
                    //rc.RamUsage = RamUsage;
                    rc.FirstProcessTime = FirstProcessTime;
                    rc.FirstQueueTime = FirstQueueTime;
                    rc.EndQueueTime = EndQueueTime;
                    rc.EndProcessTime = EndProcessTime;
                    rc.SumMessageTime = SumMessageTime;
                    rc.AvgMessageTime = AvgMessageTime;
                    rc.MaxDatetime = MaxDatetime;
                    rc.MinDatetime = MinDatetime;
                    //rc.MaxCpuUsage = MaxCpuUsage;
                    //rc.MinCpuUsage = MinCpuUsage;
                    //rc.MaxRamUsage = MaxRamUsage;
                    //rc.MinRamUsage = MinRamUsage;
                    rc.Message += "_SUCCESS";
                    endTesting = true;
                    Counter = 0;
                }
                catch (Exception exc)
                {
                    rc.Message += "_ERROR";
                    endTesting = true;
                    Counter = 0;
                }
                //執行報表製作功能，將ReportCell傳入
            }
        }

        #region Completed Testing
        #endregion

    }
    public class ReportCell
    {
        public string Name { get; set; }
        public string Message = "msg_start";
        public ConcurrentBag<DateTime> AllMessageTime { get; set; }
        public ConcurrentBag<DateTime> AllQueueTime { get; set; }
        public ConcurrentBag<int> CpuUsage { get; set; }
        public ConcurrentBag<int> RamUsage { get; set; }
        public DateTime FirstProcessTime { get; set; }
        public DateTime EndProcessTime { get; set; }
        public DateTime FirstQueueTime { get; set; }
        public DateTime EndQueueTime { get; set; }
        public TimeSpan SumMessageTime { get; set; }
        public decimal AvgMessageTime { get; set; }
        public DateTime MaxDatetime { get; set; }
        public DateTime MinDatetime { get; set; }
        public int MaxCpuUsage { get; set; }
        public int MinCpuUsage { get; set; }
        public int MaxRamUsage { get; set; }
        public int MinRamUsage { get; set; }
    }

    

}
