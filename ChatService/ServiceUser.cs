using Chat_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    public class ServiceUser
    {
        public enum TypeMsg { Connect = 1, Disconnect, Message, Info, Warning, Error };

        public UserChat user { get; set; }
        public OperationContext operationContext { get; set; }
    }
}
