//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class OurEmailList
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FromAlias { get; set; }
        public int DailyLimit { get; set; }
        public int SentCount { get; set; }
        public string IMAPHost { get; set; }
        public int IMAPPort { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<System.DateTime> EditedDateTime { get; set; }
    }
}
