using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library.Abstract;
namespace Chat_Library.Concrete
{
    public class SenderRepository : iSenderRepository
    {
        private readonly Context context;
        public SenderRepository(Context context)
        {
            this.context = context;
        }
        public tblSender AddSender(tblSender sender)
        {
            return context.tblSenders.Add(sender);
        }

        public IList<tblSender> GetAllSenders()
        {
            return context.tblSenders.ToList();
        }

        public void RemoveSender(tblSender sender)
        {
            context.tblSenders.Remove(sender);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
