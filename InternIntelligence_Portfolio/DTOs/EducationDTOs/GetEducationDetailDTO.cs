namespace Entities.DTOs.EducationDTOs
{
   public class GetEducationDetailDTO
    {
        public Guid Id { get; set; }
        public string EducationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
