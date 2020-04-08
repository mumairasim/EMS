using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class TimeTable : DtoBaseEntity
    {
        [StringLength(500)]
        public string TimeTableName { get; set; }
    }
}
