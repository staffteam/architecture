using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace YH.Framework.Web.Core.Common
{
    public class FileUtil
    {
        public readonly string SAVE_PATH = HostingEnvironment.MapPath("~/Upload");

        public string UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (!Directory.Exists(SAVE_PATH))
                {
                    Directory.CreateDirectory(SAVE_PATH);
                }
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.Combine(SAVE_PATH,filename);
                file.SaveAs(path);
                return path;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteFiles(string[] paths)
        {
            try
            {
                foreach(var path in paths)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
