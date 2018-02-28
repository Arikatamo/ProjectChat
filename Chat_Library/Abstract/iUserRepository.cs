using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library.Abstract
{
   public interface iUserRepository
    {


        tblUser AddUser(tblUser user);
        IList<tblUser> GetAll();
        void Remove(tblUser user);
        
        int SaveChanges();
    }
}
