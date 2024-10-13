namespace lr6.DBCon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Activity = new HashSet<Activity>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Surname { get; set; }

        [Required]
        [StringLength(150)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(150)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public int GenderID { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone { get; set; }

        public int? CountryID { get; set; }

        public int? DirectionID { get; set; }

        public int? EventID { get; set; }

        public string Photo { get; set; }

        public int RoleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }

        public virtual Event Event { get; set; }
    }
}
