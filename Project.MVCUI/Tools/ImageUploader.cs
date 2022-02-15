using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Tools
{
    public static class ImageUploader
    {

        //HttpPostedFileBase => MVC de eger post yontemiyle bir dosya geliyorsa bu dosya,HttpPostedFileBase tipinde tutulur

        public static string UploadImage(string serverPath,HttpPostedFileBase file)
        {
            if(file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.');
                //burada split methodu uzantiyla isim ayirir


                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if(extension == "jpg" || extension == "gif"|| extension == "jpeg" || extension == "png")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }

                    string filepath = HttpContext.Current.Server.MapPath(serverPath + fileName);

                    file.SaveAs(filepath);
                    return serverPath + fileName;



                }

                return "2"; //secilen dosya resim degildir



            }

            return "3"; //dosya bos

        }
    }
}