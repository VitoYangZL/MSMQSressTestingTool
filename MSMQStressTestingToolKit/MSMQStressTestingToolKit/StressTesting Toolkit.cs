using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Messaging;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.IO;

namespace MSMQStressTestingToolKit
{

    public partial class Form1 : Form
    {
        //manager
        public BehaviorManager BM;
        public MessageQueueManager QM;
        public TaskManager TM;
        public Console console;

        //Flag Status
        public bool EnableToGenerateQueue = false;
        public bool EnableToTest = false;
        public bool FirstTimeGenerate = true;

        //Const 
        public readonly string MessageQueueNamingLead = "mq";
        public readonly string CommonMessage = "He Said One Day You'd Leave This World Behind , So Live A Life You Will Remember.";
        public readonly string XMLMessage = "<root><forquery><account123456</account><bhno>F039000</bhno><type>3</type></forquery></root>";
        public readonly string ReportPath = @"C:\Systex\開發測試\MQStressTestingToolKit\MSMQStressTestingToolKit\MSMQStressTestingToolKit\report";

        //monitor
        PerformanceCounter CpuCounter;
        PerformanceCounter RamCounter;

        //?_?
        public Object RaceLockObj = new Object();
        public Stopwatch timer = new Stopwatch();
        public int RacingTier = 0;


        #region Initialize
        public Form1()
        {
            InitializeComponent();
            InitialiseCPUCounter();
            InitialiseRAMCounter();
            updateTimer.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BM = new BehaviorManager(this);  //input Form1(MainForm)
            QM = new MessageQueueManager();
            TM = new TaskManager();

            console = new Console(display);

            //Thread ResourceUsageThread = new Thread();

            console.Print(0, "Initialize Completed");
        }
        #endregion

        #region Setting Assist Button
        private void btnMessageQueueAmount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Amount Of Queue To Generate.");
        }
        private void btnTextAmount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Amount Of Message Gonna Send To Per Queue.");
        }
        private void btnTextPackage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Common: Only one settence\r\nXML: Short XML Format Text");
        }
        #endregion

        #region Action Button

        #region Setting Click
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            if(comMessageQueueAmount.Text != string.Empty && comTextAmount.Text != string.Empty && comTextPackage.Text != string.Empty)
            {
                try
                {
                    QM.CurrentMessageQueueAmount = Int32.Parse(comMessageQueueAmount.Text);
                    QM.CurrentTextAmount = Int32.Parse(comTextAmount.Text);
                    QM.CurrentTextPackage = comTextPackage.Text;

                    if(QM.CurrentMessageQueueAmount > 200)
                    {
                        MessageBox.Show("Error : <MessageQueue Amout> Value Out of Risky Available Range.");
                        return;
                    }
                    if(QM.CurrentMessageQueueAmount == 0 && QM.CurrentTextAmount == 0)
                    {
                        console.Print(2, "Invalid Input");
                        EnableToGenerateQueue =false;
                        NegativeButton();
                        MessageBox.Show("Error: Any Setting Fields Not Allow To Be 0!");
                        return;
                    }
                    EnableToGenerateQueue = true;
                    btnGenerateMessageQueue.Enabled = true;
                    ActiveButton();
                    console.Print(0, "Setting Saved.");

                }
                catch (Exception exc)
                {
                    console.Print(2,"Invalid Input");
                    EnableToGenerateQueue = false;
                    NegativeButton();
                    return;
                }
            }
            else
            {
                console.Print(2, "Invalid Input");
                EnableToGenerateQueue = false;
                NegativeButton();
                MessageBox.Show("Error: All Setting Fields Are Necessary !");
                return;
            }
        }
        #endregion

        #region Clear Setting Click
        private void btnClearSetting_Click(object sender, EventArgs e)
        {
            comMessageQueueAmount.Text = null;
            comTextAmount.Text = null;
            comTextPackage.Text = null;

            EnableToGenerateQueue = false;
            EnableToTest = false;

            QM.CurrentMessageQueueAmount = 0;
            QM.CurrentTextAmount = 0;
            NegativeButton();
            console.Print(0, "Clear Setting Completed.");
        }
        #endregion

        #region Generate Click
        private void btnGenerateMessageQueue_Click(object sender, EventArgs e)
        {
            DeleteAllMessageQueue();
            QM.DictMessageQueueUnit.Clear();
            string KeyStr = string.Empty;
            string TargetPath = string.Empty;

            if (EnableToGenerateQueue)
            {
                try
                {
                    for (var k = 0;k< QM.CurrentMessageQueueAmount; k++)
                    {
                        if(k< QM.CurrentMessageQueueAmount)
                        {
                            KeyStr = "mq" + k.ToString();
                            TargetPath = @".\private$\" + KeyStr;

                            if (!MessageQueue.Exists(TargetPath))
                            {
                                MessageQueue.Create(TargetPath);
                                MessageQueueUnit MQU = new MessageQueueUnit(KeyStr,TargetPath);
                                QM.CurrentMessageQueue = MQU.MQ;
                                QM.CurrentMessageQueue.SetPermissions("Everyone", MessageQueueAccessRights.ReceiveMessage, AccessControlEntryType.Allow);
                                QM.DictMessageQueueUnit.Add(KeyStr, MQU);
                            }
                        }
                        
                    }
                    console.Print(0, "MessageQueue Generating Completed.");
                }
                catch(Exception exc)
                {
                    console.Print(3, "Generate<" + TargetPath + "> Failed. ErrorMessage: " + exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Your Setting Isn't Prepared yet!");
                return;
            }
        }
        #endregion

        #region Clear MessageQueue Click
        private void btnClearMessageQueue_Click(object sender, EventArgs e)
        {
            int count = QM.DictMessageQueueUnit.Count;

            try
            {
                if(QM.DictMessageQueueUnit.Count == 0)
                {
                    console.Print(2, "There is no Queue in Yourr System");
                    return;
                }
                for (var i = 0; i < count; i++)
                {
                    MessageQueueUnit mqu = new MessageQueueUnit();
                    QM.DictMessageQueueUnit.TryGetValue(MessageQueueNamingLead + i.ToString(), out mqu);
                    mqu.MQ.Purge();
                }
                console.Print(0, "All Queue had been pruged.");
            }
            catch(Exception exc)
            {
                console.Print(3, "Failed To Clear MessageQueue Intern,Now Is Disable To Execute Testing, ErrorMessage: " + exc.Message);
                EnableToTest = false;
            }
            
        }
        #endregion

        #region EXPLOSION Click
        private void btnManualDeleteMessageQueueAndDict_Click(object sender, EventArgs e)
        {
            DeleteAllMessageQueue();
            QM.DictMessageQueueUnit = new Dictionary<string, MessageQueueUnit>();
            console.Print(0, "Deleted All MessageQueue Path And Reset All Key Value Pairs");
        }
        #endregion

        #region Testing <TimeGap> Click
        private void btnTimeGapTest_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                string strSending = GetSendingString(QM);
                TM.StartTesting_TimeGap(QM, strSending);

                #region Lock Button
                btnBrutalTest.Enabled = false;
                btnClearMessageQueue.Enabled = false;
                btnClearSetting.Enabled = false;
                btnCompletedTest.Enabled = false;
                btnManualDeleteMessageQueueAndDict.Enabled = false;
                btnSaveSetting.Enabled = false;
                btnTimeGapTest.Enabled = false;
                btnGenerateMessageQueue.Enabled = false;
                #endregion

                #region Check if testing done or not
                bool switcher = true;
                while(switcher){
                    if (TM.endTesting)
                    {
                        switcher = false;
                        console.ReportGenerating(TM);
                        string fileNameHead = DateTime.Now.ToString("yyyy-MM-dd");
                        string fileNameBody = TM.rc.Name + "_Report";
                        string fileString = ReportPath + @"\" + fileNameHead + fileNameBody + ".txt";
                        if (!Directory.Exists(ReportPath))
                        {
                            Directory.CreateDirectory(ReportPath);
                        }

                        if (!File.Exists(fileString))
                        {
                            File.Create(fileString);
                            
                        }

                        //Report here
                        //StreamWriter sw = new StreamWriter(fileString);
                        //sw.WriteLine();
                    }
                    Thread.Sleep(250);
                }
                #region Release Button
                btnBrutalTest.Enabled = true;
                btnClearMessageQueue.Enabled = true;
                btnClearSetting.Enabled = true;
                btnCompletedTest.Enabled = true;
                btnManualDeleteMessageQueueAndDict.Enabled = true;
                btnSaveSetting.Enabled = true;
                btnTimeGapTest.Enabled = true;
                btnGenerateMessageQueue.Enabled = true;
                #endregion

                #endregion

            });
            
        }
        #endregion

        #region Action Method
        private void ActiveButton()
        {
            btnCompletedTest.Enabled = true;
            btnTimeGapTest.Enabled = true ;
            btnBrutalTest.Enabled = true;
            btnGenerateMessageQueue.Enabled = true;
        }

        private void NegativeButton()
        {
            btnCompletedTest.Enabled = false;
            btnTimeGapTest.Enabled = false;
            btnBrutalTest.Enabled = false;

            btnGenerateMessageQueue.Enabled = false;
            
        }

        private void DeleteAllMessageQueue()
        {
            int count = QM.DictMessageQueueUnit.Count;
            try
            {
                if (!FirstTimeGenerate)
                {
                    console.Print(0, "All MessageQueue is Delete Completed.");
                }
                else
                {
                    FirstTimeGenerate = false;
                }

                for (var i = 0; i < 200; i++)
                {
                    MessageQueue mq = new MessageQueue(@".\private$\MQ" + i.ToString());
                    if (MessageQueue.Exists(mq.Path))
                    {
                        MessageQueue.Delete(mq.Path);
                        console.Print(0, "MQ" + i.ToString() + " had been removed");
                    }
                }
                
            }
            catch (Exception exc)
            {
                console.Print(3, "MessageQueue Purging Failed , errorMessage: " + exc.Message);
            }
            
        }








        #endregion

        #endregion

        private void btnBrutalTest_Click(object sender, EventArgs e)
        {
        }

        public string GetSendingString(MessageQueueManager qm )
        {
            TM.MessageAmount = qm.CurrentTextAmount;
            TM.QueueAmount = qm.CurrentMessageQueueAmount;
            if (qm.CurrentTextPackage == "COMMON")
            {
                return CommonMessage;
            }
            else if (qm.CurrentTextPackage == "XML")
            {
                return XMLMessage;
            }
            else
            {
                return "FAIL_MESSAGE";
            }
        }

        public void InitialiseCPUCounter()

        {

            CpuCounter = new PerformanceCounter("Processor","% Processor Time","_Total",true);

        }
        public void InitialiseRAMCounter()

        {

            RamCounter = new PerformanceCounter("Memory", "Available MBytes", true);

        }
        public void updateTimer_Tick_1(object sender, EventArgs e)
        {
            lblCpuNum.Text = Convert.ToInt32(CpuCounter.NextValue()).ToString();

            lblRamNum.Text = Convert.ToInt32(RamCounter.NextValue()).ToString();
        }
    }
}