using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ChatService.ServiceUser;

namespace ChatService
{
     [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string username, string msg, TypeMsg typeMsg, int userId);
    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string username, string msg, TypeMsg typeMsg);
    }
}
