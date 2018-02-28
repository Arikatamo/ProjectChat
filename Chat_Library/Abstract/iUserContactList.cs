using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library.Abstract
{
    public  interface iUserContactList
    {
        IList<tblContactList> GetAllContacts();
        tblContactList AddContact(tblContactList contact);
        void RemoveContact(tblContactList contact);
        int SaveChanges(); 
    }
}
