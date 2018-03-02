using Chat_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    public class UserChat
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserChat()
        {
            this.tblContactLists = new HashSet<tblContactList>();
            this.tblSenders = new HashSet<tblSender>();
            this.tblChats = new HashSet<tblChat>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreate { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContactList> tblContactLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<tblSender> tblSenders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChat> tblChats { get; set; }

        public static implicit operator UserChat(tblUser v)
        {
            return new UserChat
            {
                Name = v.Name,
                Image = v.Image,
                id = v.id,
                Phone = v.Phone,
                DateCreate = v.DateCreate,
                tblChats = v.tblChats,
                tblContactLists = v.tblContactLists,
                tblSenders = v.tblSenders
            };
        }
    }
}
