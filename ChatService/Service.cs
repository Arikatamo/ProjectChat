using Chat_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ChatService.ServiceUser;
using BLL.Abstract;
using BLL.Concrete;

namespace ChatService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IServiceChat
    {
        List<ServiceUser> users = new List<ServiceUser>();
      private readonly   UserProvider provider = new UserProvider();
        public int Connect(string name)
        {
            var user = new UserProvider().GetAllUsers().FirstOrDefault(m => m.Name == name);

            if (users.FirstOrDefault(m => m.user.Name == name) != null || user == null)
            {
                SendMsg("", "Пользователь с таким ником уже есть в чате!", TypeMsg.Error, 0);
                return 0;
            }

            ServiceUser newUser = new ServiceUser()
            {
                user = user,
                operationContext = OperationContext.Current
            };

            SendMsg(name, "подключился к чату!", TypeMsg.Connect, 0);
            users.Add(newUser);

            return user.id;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(m => m.user.id == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(user.user.Name, "покинул чат!", TypeMsg.Disconnect, 0);
            }
        }
        public void SendMsg(string username, string msg, TypeMsg typeMsg, int userId)
        {
            foreach (var el in users)
            {
              el.operationContext.GetCallbackChannel<ICallback>().MsgCallback(username, msg, typeMsg);
            }
        }

    }
}
