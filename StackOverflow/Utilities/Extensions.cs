using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StackOverflow.Utilities
{
	public static  class Extensions
	{
        public static bool ImageIsOkay(this IFormFile file, int mb)
        {
            return file.Length / 1024 / 1024 < mb && file.ContentType.Contains("image/");

        }


        public static async Task<string> FileCreate(this IFormFile file, string root, string folder)
        {
            string fileName = string.Concat(Guid.NewGuid(), file.FileName);
            string path = Path.Combine(root, folder);
            string filePath = Path.Combine(path, fileName);
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {

                throw new FileLoadException();
            }
            return fileName;
        }
    }
}

