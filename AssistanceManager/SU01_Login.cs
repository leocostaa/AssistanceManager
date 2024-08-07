//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssistanceManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class SU01_Login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SU01_Login()
        {
            this.AssistanceDetail = new HashSet<AssistanceDetail>();
            this.Technicians = new HashSet<Technicians>();
        }
    
        public int LoginID { get; set; }
        public string LoginType { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public string LoginPincode { get; set; }
        public Nullable<System.DateTime> LoginDateEnd { get; set; }
        public Nullable<int> LoginEnabled { get; set; }
        public string LoginDisplayName { get; set; }
        public string LoginEmail { get; set; }
        public string LoginCellPhone { get; set; }
        public string LoginJobPosition { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssistanceDetail> AssistanceDetail { get; set; }
        public virtual SU00_LoginType SU00_LoginType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Technicians> Technicians { get; set; }
    }
}
