
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhotoGalleryCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhotoGalleryCategory()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int PhotoGalleryCategoryID { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
