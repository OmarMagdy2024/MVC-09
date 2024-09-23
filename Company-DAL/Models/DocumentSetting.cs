using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_DAL.Models
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            string filename = $"{Guid.NewGuid()}{file.FileName}";
            string filePath=Path.Combine(folderPath,filename);
           using var fileStream=new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return filename;
        }
        public static void DeleteFile(string fileName, string folderName)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName,fileName);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
