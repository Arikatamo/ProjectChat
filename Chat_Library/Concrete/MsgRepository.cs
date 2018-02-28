using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library.Abstract;
namespace Chat_Library.Concrete
{
    public class MsgRepository : iMsgRepository
    {
        private readonly Context context;
        MsgRepository(Context context)
        {
            this.context = context;
        }
        public tblMessage AddMessage(tblMessage Msg)
        {
          return context.tblMessages.Add(Msg);
        }

        public IList<tblMessage> GetAllMsg()
        {
           return context.tblMessages.ToList();
        }

        public void RemoveMsg(tblMessage Msg)
        {
            context.tblMessages.Remove(Msg);
        }

        public int SaveChanges()
        {
           return context.SaveChanges();
        }
    }
}
