namespace Core.Helpers
{
  public  class wwwrootGetPath
    {
        public static string GetwwwrootPath
        {
            get
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                return path;

            }
        }
    }
}
