using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library.Abstract;
namespace ChatBLL.Abstract
{
    public interface iUserProvider
    {
        void AddUser(string name, string phone, string image);
    }
}
