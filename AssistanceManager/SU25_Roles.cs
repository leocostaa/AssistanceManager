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
    
    public partial class SU25_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SU25_Roles()
        {
            this.SU24_Authorizations = new HashSet<SU24_Authorizations>();
        }
    
        public int RoleID { get; set; }
        public string RoleDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SU24_Authorizations> SU24_Authorizations { get; set; }
    }
}
