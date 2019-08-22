using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Service.Business
{
    public interface IPictureService
    {
        int CreateModel(Picture model);

        void UpdateModel(Picture model);

        void DeleteModel(int id);

        void DeleteModels(IEnumerable<Picture> list);

        Picture GetModel(int id);
    }
}
