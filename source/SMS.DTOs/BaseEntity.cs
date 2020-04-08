using System;

namespace SMS.DTOs
{
    public class DtoBaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
