using System.Collections.Generic;

namespace ConfigReader.Entities
{
    public class Message
    {
        private bool _status = true;
        public Message()
        {
            //Messages ??= new List<string>();
            if (Messages == null)
            {
                Messages = new List<string>();
            }
        }

        public object OutParam { get; set; }
        public List<string> Messages { get; set; }
        public string UserMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public int ScreenId { get; set; }
        public string ApiAddress { get; set; }
        public bool Status
        {
            get { return _status; }
        }

        public void Fail()
        {
            _status = false;
        }
    }

}
