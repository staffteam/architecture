using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Data;
using YH.Framework.Core.Domain.Business;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Business
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> menuRepository;

        public MenuService(IRepository<Menu> userRepository)
        {
            this.menuRepository = userRepository;
        }

        public void CreateModel(Menu model)
        {
            this.menuRepository.Insert(model);
        }

        public void UpdateModel(Menu model)
        {
            menuRepository.Update(model);
        }

        public void DeleteModel(int id)
        {
            Menu menu = menuRepository.GetById(id);

            if (menu.Childrens.Any())
            {
                foreach (var item in menu.Childrens.ToList())
                {
                    DeleteModel(item.ID);
                }
            }
            menuRepository.Delete(menu);
        }

        public Menu GetModel(int id)
        {
            return this.menuRepository.GetById(id);
        }

        public List<Menu> GetModels()
        {
            return menuRepository.Table.ToList();
        }

        public IPagedList<Menu> GetModels(string keyword, int pageNumber, int pageSize)
        {
            var menus = menuRepository.Table;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                menus = menus.Where(p => p.Name.Contains(keyword));
            }

            return menus.ToPagedList(m => m.ID, pageNumber, pageSize);
        }
    }
}
