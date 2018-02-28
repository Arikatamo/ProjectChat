using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBLL.Abstract;
using Chat_Library.Abstract;
using Chat_Library.Concrete;

namespace ChatBLL.Concrete
{
    public class UserProvider : iUserProvider
    {
        private readonly iUserRepository _iUserRepository;
        private readonly iUserContactList _iUserContactList;
        private readonly iMsgRepository _iMsgRepository;
        private readonly iSenderRepository _iSenderRepository;
        UserProvider()
        {
            Chat_Library.Context context = new Chat_Library.Context();
            _iMsgRepository = new MsgRepository(context);
        }
        public void AddUser(string name, string phone, string image)
        {
            throw new NotImplementedException();
        }
    }
}
