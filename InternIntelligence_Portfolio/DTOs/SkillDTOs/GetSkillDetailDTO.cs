namespace Entities.DTOs.SkillDTOs
{
  public  class GetSkillDetailDTO
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public bool IsBackend { get; set; }
    }
}
