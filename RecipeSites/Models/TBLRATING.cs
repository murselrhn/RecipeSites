//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeSites.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLRATING
    {
        public int Rating_Id { get; set; }
        public Nullable<int> Value { get; set; }
        public Nullable<int> User { get; set; }
    
        public virtual TBLUSER TBLUSER { get; set; }
    }
}
