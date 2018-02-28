using Chat_Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Chat_Library.Concrete
{
    public class UserRepository : iUserRepository
    {
        private readonly Context context;
        public UserRepository(Context context)
        {
            this.context = context;
        }
        public tblUser AddUser(tblUser user)
        {
            context.tblUsers.Add(user);
            return user;
        }

        public IList<tblUser> GetAll()
        {
           return  context.tblUsers.ToList();
        }

        public void Remove(tblUser user)
        {
            context.tblUsers.Remove(user);
        }

        public int SaveChanges()
        {
           return context.SaveChanges();
        }
    }
}
