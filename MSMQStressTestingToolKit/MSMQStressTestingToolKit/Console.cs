using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MSMQStressTestingToolKit
{
    public class Console
    {
        public RichTextBox dp;
        public Console(RichTextBox rtb)
        {
            dp = rtb;
        }
        public void Print(string str)
        {
            dp.AppendText("Normal: ");
            dp.AppendText(str);
            dp.AppendText("\r\n");
        }
        public void Print(int tier , string str)
        {

            string comb = str + "\r\n";
            
            switch (tier.ToString())
            {
                case "0":
                    dp.SelectionColor = Color.Black;
                    dp.AppendText("Normal :  "+comb);
                    break;
                case "1":
                    dp.SelectionColor = Color.Black;
                    dp.AppendText("Report :  " + comb);
                    break;
                case "2":
                    dp.SelectionColor = Color.Orange;
                    dp.AppendText("Warning :  " + comb);
                    break;
                case "3":
                    dp.SelectionColor = Color.Red;
                    dp.AppendText("Emergency :  " + comb);
                    break;
                case "9":
                    dp.AppendText(comb);
                    break;
                default:
                    dp.SelectionColor = Color.Red;
                    dp.AppendText("<!--TEXT PRINTING FAILED--!>");
                    break;
            }
        }

        public void ReportGenerating(Object obj)
        {
            var data = (TaskManager)obj;
            var cell = data.rc;


            switch (data.rc.Name)
            {
                case "timegap":
                    ReportBorder();
                    dp.SelectionColor = Color.Black;
                    dp.AppendText("Testing Mode : " + cell.Name + "\r\n");
                    dp.AppendText("Message : " + cell.Message + "\r\n");
                    dp.AppendText("Total Messages Time : " + cell.SumMessageTime + "\r\n");
                    dp.AppendText("Average Message Time : " + cell.AvgMessageTime.ToString() + "  ms\r\n");
                    dp.AppendText("First Data : " + cell.MinDatetime.ToString("yyyy-MM-dd-HH:mm:ss.fff") + "\r\n");
                    dp.AppendText("Last Data : " + cell.MaxDatetime.ToString("yyyy-MM-dd-HH:mm:ss.fff") + "\r\n");
                    ReportBorder();
                    break;
                case "completed":
                    break;
                case "brutal":
                    break;
                default:
                    break;

            }

        }

        private void ReportBorder()
        {
            dp.SelectionColor = Color.Red;
            dp.AppendText("==========   Report Data ==========" + "\r\n");
        }

    }

}
