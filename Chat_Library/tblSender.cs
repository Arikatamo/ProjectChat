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
    
    public partial class tblSender
    {
        public int UserId { get; set; }
        public int ToId { get; set; }
        public int MessageId { get; set; }
    
        public virtual tblMessage tblMessage { get; set; }
        public virtual tblUser tblUser { get; set; }
        public virtual tblMessage tblMessage1 { get; set; }
    }
}
