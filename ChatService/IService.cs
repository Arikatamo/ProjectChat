using Chat_Library;
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
        UserChat Connect(UserChat name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract]
        IList<UserChat> GetAllOnlineUsers();

        [OperationContract(IsOneWay = true)]
        void SendMsg(UserChat username, string msg, TypeMsg typeMsg, int userId);
    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(UserChat username, string msg, TypeMsg typeMsg);    }
}
