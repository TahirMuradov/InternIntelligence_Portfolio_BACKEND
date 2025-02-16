namespace Entities
{
    public class Education
    {
        public Guid Id { get; set; }
        public string EducationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
