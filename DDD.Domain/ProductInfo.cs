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
    
    public partial class ProductInfo
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    
        public virtual OrderItem OrderItem { get; set; }
    }
}