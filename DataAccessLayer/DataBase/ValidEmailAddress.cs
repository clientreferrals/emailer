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
    
    public partial class ValidEmailAddress
    {
        public int Id { get; set; }
        public string ValidEmailAddresses { get; set; }
        public bool IsValid { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public Nullable<System.DateTime> EditDateTime { get; set; }
    }
}
