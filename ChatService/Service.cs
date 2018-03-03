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
        private readonly UserProvider provider = new UserProvider();
        public UserChat Connect(UserChat name)
        {
            var user = new UserProvider().GetAllUsers().FirstOrDefault(m => m.id == name.id);

            if (users.FirstOrDefault(m => m.user == name) != null || user == null)
            {
                SendMsg(name, "Пользователь с таким ником уже есть в чате!", TypeMsg.Error, 0);
                return new UserChat() ;
            }
            ServiceUser newUser = new ServiceUser()
            {
                user = name,
                operationContext = OperationContext.Current
            };

            SendMsg(name, "подключился к чату!", TypeMsg.Connect, 0);
            users.Add(newUser);
            return newUser.user;
        }

        public void Disconnect(int id)
        {
           
            var user = users.FirstOrDefault(m => m.user.id == id);
            if (user != null)
            {
                users.RemoveAt(users.FindIndex(m => m.user.id == id));
                SendMsg(user.user, "покинул чат!", TypeMsg.Disconnect, 0);

            }
        }

        public IList<UserChat> GetAllOnlineUsers()
        {
            return users.ConvertAll(new Converter<ServiceUser, UserChat>(ServiceUserToString));
        }

        public UserChat ServiceUserToString(ServiceUser user)
        {
            return user.user;
        }

        public void SendMsg(UserChat username, string msg, TypeMsg typeMsg, int userId)
        {
            foreach (var el in users)
            {
              el.operationContext.GetCallbackChannel<ICallback>().MsgCallback(username, msg, typeMsg);
            }
        }

    }
}
