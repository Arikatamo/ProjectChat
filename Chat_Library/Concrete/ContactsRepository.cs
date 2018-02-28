using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library.Abstract;
namespace Chat_Library.Concrete
{
    public class ContactsRepository : iUserContactList
    {
        private readonly Context context;
        ContactsRepository(Context context)
        {
            this.context = context;
        }

        public tblContactList AddContact(tblContactList contact)
        {
           return context.tblContactLists.Add(contact);
        }

        public IList<tblContactList> GetAllContacts()
        {
            return context.tblContactLists.ToList();
        }

        public void RemoveContact(tblContactList contact)
        {
            context.tblContactLists.Remove(contact);
        }

        public int SaveChanges()
        {
           return context.SaveChanges();
        }
    }
}
