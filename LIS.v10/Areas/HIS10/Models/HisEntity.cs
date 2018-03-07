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
    
    public partial class HisEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HisEntity()
        {
            this.HisInstruments = new HashSet<HisInstrument>();
            this.HisEntCats = new HashSet<HisEntCat>();
            this.HisEntPhysicians = new HashSet<HisEntPhysician>();
            this.HisEntOperators = new HashSet<HisEntOperator>();
            this.HisEntAdmins = new HashSet<HisEntAdmin>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int userGroupId { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisInstrument> HisInstruments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisEntCat> HisEntCats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisEntPhysician> HisEntPhysicians { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisEntOperator> HisEntOperators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisEntAdmin> HisEntAdmins { get; set; }
    }
}