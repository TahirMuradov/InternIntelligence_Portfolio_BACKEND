namespace Entities.DTOs.EducationDTOs
{
  public  class GetEducationForUIDTO
    {
        public string EducationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
