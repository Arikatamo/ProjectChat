//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat_Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMessage()
        {
            this.tblSenders = new HashSet<tblSender>();
            this.tblSenders1 = new HashSet<tblSender>();
        }
    
        public int id { get; set; }
        public string Message { get; set; }
        public System.DateTime SendDate { get; set; }
        public int UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSender> tblSenders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSender> tblSenders1 { get; set; }
    }
}
