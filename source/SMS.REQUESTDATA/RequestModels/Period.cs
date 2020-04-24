using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("Period")]
    public partial class Period : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Period()
        {
            TimeTableDetails = new HashSet<TimeTableDetail>();
        }

        [StringLength(50)]
        public string PeriodNumber { get; set; }

        public TimeSpan? FromTime { get; set; }

        public TimeSpan? ToTime { get; set; }

        public int? SchoolId { get; set; }

        public int? RequestTypeId { get; set; }

        public virtual RequestType RequestType { get; set; }
        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTableDetail> TimeTableDetails { get; set; }
    }
}
