using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library.Abstract
{
    public interface iMsgRepository
    {
        IList<tblMessage> GetAllMsg();
        tblMessage AddMessage(tblMessage Msg);
        void RemoveMsg(tblMessage Msg);
        int SaveChanges();
    }
}
