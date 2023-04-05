using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using StackOverflow.Models;

namespace StackOverflow.Utilities
{
	public class Methods
	{
        public static void FileDelete(string root, string folder, string image)
        {
            string filePath = Path.Combine(root, folder, image);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        public static bool CheckAward(int? id, Award existed)
        {
            if (existed != null && existed.Id != id)
            {
                return true;
            }
            return false;
        }

        public static bool HaveImage(IFormFile file)
        {
            if (file != null)
            {
                return true;
            }
            return false;

        }
    }
}

