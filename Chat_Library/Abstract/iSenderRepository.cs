using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library.Abstract
{
    public interface iSenderRepository
    {
        tblSender AddSender(tblSender sender);
        IList<tblSender> GetAllSenders();
        void RemoveSender(tblSender sender);
        int SaveChanges();
    }
}
