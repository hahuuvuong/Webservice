//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testAPIDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartItem
    {
        public int Id { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public int ProId { get; set; }
        public int CartId { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
