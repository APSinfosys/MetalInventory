//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryDal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master_BankAccountMaster
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string address { get; set; }
        public string IFSC { get; set; }
        public string Holder { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<int> freez { get; set; }
        public Nullable<int> companyId { get; set; }
        public Nullable<int> yearId { get; set; }
        public Nullable<decimal> OpeningBal { get; set; }
    }
}