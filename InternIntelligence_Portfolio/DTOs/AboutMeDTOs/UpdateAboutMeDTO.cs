using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AboutMeDTOs
{
   public class UpdateAboutMeDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Nationality { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }
    }
}
