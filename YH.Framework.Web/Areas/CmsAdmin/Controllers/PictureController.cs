using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Core.Domain.Business;
using YH.Framework.Core.Infrastructure;
using YH.Framework.Service.Business;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Areas.CmsAdmin.Controllers
{
    public class PictureController : BaseController
    {
        private readonly IPictureService pictureService;

        private readonly IWorkContext workContext;

        private readonly IMapper mapper;

        private readonly IConfigurationProvider mapperConfigProvider;

        public PictureController(IPictureService pictureService, IWorkContext workContext, IMapper mapper, IConfigurationProvider mapperConfigProvider)
        {
            this.pictureService = pictureService;
            this.workContext = workContext;
            this.mapperConfigProvider = mapperConfigProvider;
            this.mapper = mapperConfigProvider.CreateMapper();
        }

        /// <summary>
        /// 根据编号集删除图片信息
        /// </summary>
        /// <param name="Ids">编号集</param>
        /// <returns></returns>
        public ActionResult DeletePictures(String Ids)
        {
            if (!String.IsNullOrEmpty(Ids))
            {
                try
                {
                    List<Picture> list = new List<Picture>();
                    foreach (var item in Ids.Split(','))
                    {
                        Picture Model = pictureService.GetModel(Convert.ToInt32(item));
                        list.Add(Model);
                    }

                    pictureService.DeleteModels(list);

                    foreach (var item in list)
                    {
                        if (System.IO.File.Exists(item.FullName))
                        {
                            System.IO.File.Delete(item.FullName);
                        }
                    }
                    return Json(1);
                }
                catch (Exception)
                {
                    return Json(-1);
                }
            }
            else
            {
                return Json(0);
            }
        }

        public ActionResult SingleUpload()
        {
            Picture model = new Picture();
            try
            {
                string uploadPath = Server.MapPath("~/UploadFiles");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                HttpPostedFileBase f = Request.Files[0];
                String Ids = Request.Form["id"].ToString();

                string ext = Path.GetExtension(f.FileName);

                Guid g = Guid.NewGuid();
                string filename = Path.Combine(uploadPath, g + ext);
                f.SaveAs(filename);

                int id = 0;
                model.Src = string.Format("UploadFiles/{0}{1}", g, ext);
                model.NewName = g + ext;
                model.FullName = filename;
                model.Name = f.FileName;
                id=pictureService.CreateModel(model);
                DeletePictures(Ids);
                return Json(new { status = true, name = model.Name, id, url = model.Src });
            }
            catch (Exception e)
            {
                if (System.IO.File.Exists(model.FullName))
                {
                    System.IO.File.Delete(model.FullName);
                }
                return Json(new { status = false, msg = "上传失败！",errmsg=e.Message });
            }
        }

        public ActionResult ListUpload()
        {
            IList<Picture> list = new List<Picture>();
            try
            {
                string uploadPath = Server.MapPath("~/UploadFiles");
                String Ids = Request.Form["Ids"].ToString();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    Picture model = new Picture();

                    HttpPostedFileBase f = Request.Files[i];
                    string ext = Path.GetExtension(f.FileName);

                    Guid g = Guid.NewGuid();
                    string filename = Path.Combine(uploadPath, g + ext);
                    f.SaveAs(filename);

                    int id = 0;
                    model.Src = string.Format("UploadFiles/{0}{1}", g, ext); ;
                    model.NewName = g + ext;
                    model.FullName = filename;
                    model.Name = f.FileName;

                    id=pictureService.CreateModel(model);
                    model.ID = id;

                    list.Add(model);
                }

                DeletePictures(Ids);

                return Json(new { success = true, List = list });
            }
            catch
            {
                foreach (var item in list)
                {
                    if (System.IO.File.Exists(item.FullName))
                    {
                        System.IO.File.Delete(item.FullName);
                    }
                }
                return Json(new { success = false, msg = "上传失败！" });
            }
        }
    }
}