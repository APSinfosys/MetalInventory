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
    
    public partial class Master_CommonValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Master_CommonValue()
        {
            this.Master_RoleMaster = new HashSet<Master_RoleMaster>();
        }
    
        public int Id { get; set; }
        public int CommonType { get; set; }
        public string CommonValue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Master_RoleMaster> Master_RoleMaster { get; set; }
    }
}
