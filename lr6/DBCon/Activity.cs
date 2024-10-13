namespace lr6.DBCon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int EventPlanID { get; set; }

        public int Day { get; set; }

        public TimeSpan StartedAt { get; set; }

        public int? ModeratorID { get; set; }

        [StringLength(100)]
        public string GroupsJury { get; set; }

        public virtual User User { get; set; }
    }
}
