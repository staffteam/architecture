using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Business
{
    public interface IMenuService
    {
        void CreateModel(Menu model);

        void UpdateModel(Menu model);

        Menu GetModel(int id);

        void DeleteModel(int id);

        List<Menu> GetModels();

        IPagedList<Menu> GetModels(string keyword, int pageNumber, int pageSize);
    }
}
