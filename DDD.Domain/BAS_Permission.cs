//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDD.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class BAS_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAS_Permission()
        {
            this.BAS_PPSet = new HashSet<BAS_PPSet>();
        }
    
        public System.Guid Id { get; set; }
        public string CodeProperty { get; set; }
        public OperationType Operation { get; set; }
        public string CodeValue { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid Per_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAS_PPSet> BAS_PPSet { get; set; }
    }
}
