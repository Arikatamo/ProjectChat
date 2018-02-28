using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library.Abstract;
using System.Data.Entity;
namespace Chat_Library.Concrete
{
    public class MsgRepository : iMsgRepository
    {
       private readonly Context _context;

        public MsgRepository(Context context)
        {
            this._context = context;
        }
        public tblMessage AddMessage(tblMessage Msg)
        {
          return _context.tblMessages.Add(Msg);
        }

        public IList<tblMessage> GetAllMsg()
        {
           return _context.tblMessages.ToList();
        }

        public void RemoveMsg(tblMessage Msg)
        {
            _context.tblMessages.Remove(Msg);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
