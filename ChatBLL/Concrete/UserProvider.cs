using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBLL.Abstract;
using Chat_Library.Concrete;
using Chat_Library;
namespace ChatBLL.Concrete
{
    public class UserProvider
    {
        Context context = new Context();
        UserRepository user = new UserRepository();
        UserProvider()
        {
        }
        public void AddUser(string name, string phone, string image)
        {
            throw new NotImplementedException();
        }
    }
}
