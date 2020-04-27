using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("TimeTable")]
    public partial class TimeTable : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeTable()
        {
            TimeTableDetails = new HashSet<TimeTableDetail>();
        }

        [StringLength(500)]
        public string TimeTableName { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTableDetail> TimeTableDetails { get; set; }
    }
}
