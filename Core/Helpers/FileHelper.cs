using Microsoft.AspNetCore.Http;
namespace Core.Helpers

{
   public static class FileHelper
    {
        public static async Task<string> SaveFileAsync(this IFormFile file)
        {
            string filePath = Path.Combine(wwwrootGetPath.GetwwwrootPath, "uploads");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var path = "/uploads/" + Guid.NewGuid().ToString() + file.FileName.Replace(' ', '_');
            using FileStream fileStream = new(Path.Combine(wwwrootGetPath.GetwwwrootPath + path), FileMode.Create);
            await file.CopyToAsync(fileStream);
            return path;
        }
        public static bool RemoveFile(this string FilePaths)
        {
            string filePath = Path.Combine(wwwrootGetPath.GetwwwrootPath + FilePaths.Replace("/", "\\"));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

            }
            else
                return false;
            return true;
        }
    }
}
