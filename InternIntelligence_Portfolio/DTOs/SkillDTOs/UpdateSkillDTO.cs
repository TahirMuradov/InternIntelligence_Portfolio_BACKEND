namespace Entities.DTOs.SkillDTOs
{
  public  class UpdateSkillDTO
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public bool IsBackend { get; set; }
    }
}
