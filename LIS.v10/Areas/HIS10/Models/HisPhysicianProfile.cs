//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIS.v10.Areas.HIS10.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HisPhysicianProfile
    {
        public int Id { get; set; }
        public int HisPhysicianId { get; set; }
        public int HisProfileId { get; set; }
    
        public virtual HisPhysician HisPhysician { get; set; }
        public virtual HisProfile HisProfile { get; set; }
    }
}
