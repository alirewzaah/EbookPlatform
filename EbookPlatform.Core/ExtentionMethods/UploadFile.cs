using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.ExtentionMethods
{
    public class UploadFile
    {
        public static string CreateFile(IFormFile file)
        {
            try
            {
             
                string imgname = GenerateCode.GuidCode() + Path.GetExtension(file.FileName);
                string Pathimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CssSite/SiteFiles", imgname);
                // string Pathimgthumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/thumb", imgname);

                // string imagesecurity = file.ImageSecurity();

                // if (imagesecurity == "false")
                //   return "false";

                using (var stream = new FileStream(Pathimg, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                // ConvertImage convert = new ConvertImage();
                //convert.Image_resize(Pathimg, Pathimgthumb, 400, 400);

                return imgname;
            }
            catch (Exception)
            {
                return "false";
            }

        }

        public static int DeleteFile(string path, string filename)
        {
            try
            {
                string FullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CssSite/" + path + "/" + filename);
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return 1;
                }
                return 2;
            }
            catch (Exception)
            {
                return 3;
            }
        }
    }
}
