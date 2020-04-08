namespace SMS.DTOs
{
    public class StudentFinanceDetail : DtoBaseEntity
    {
        public int? StudentId { get; set; }
        public decimal? Fee { get; set; }

        public int? FinanceTypeId { get; set; }

    }
}
