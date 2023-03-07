using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace MSMQStressTestingToolKit
{
    public class MessageQueueManager
    {
        //Head Storage
        public Dictionary<string, MessageQueueUnit> DictMessageQueueUnit;
        public MessageQueueManager()
        {
            DictMessageQueueUnit = new Dictionary<string, MessageQueueUnit>();
        }

        // Current Variable
        public MessageQueue CurrentMessageQueue = null;
        public string CurrentMessageQueueName = string.Empty;
        public int CurrentMessageQueueAmount { get; set; }
        
        public int CurrentTextAmount { get; set; }
        public string CurrentTextPackage = string.Empty;




    }

    public class MessageQueueUnit
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }
        public MessageQueue MQ { get; set; }
        public bool? SendingFlag { get; set; }
        public bool? ReceivingFlag { get; set; }

        public MessageQueueUnit()
        {
            Name = string.Empty;
            Path = string.Empty;
            Message = string.Empty;
            MQ = new MessageQueue();
            SendingFlag = null;
            ReceivingFlag = null;
        }

        public MessageQueueUnit(string id,string path)
        {
            Name = "mq" + id.ToString();
            Path = @".\private$\" + Name;
            Message = string.Empty;
            MQ = new MessageQueue(path);
            SendingFlag = false;
            ReceivingFlag = false;
        }
        private bool CheckFieldsCompleted()
        {
            try
            {
                if(String.IsNullOrEmpty(Name) || Path=="mq" || SendingFlag == null || ReceivingFlag == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }

    }
}
