using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Data;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Service.Business
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> pictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public int CreateModel(Picture model)
        {
            this.pictureRepository.Insert(model);

            return this.pictureRepository.Table.Max(t=>t.ID);
        }

        public void UpdateModel(Picture model)
        {
            this.pictureRepository.Update(model);
        }

        public void DeleteModel(int id)
        {
            Picture model = this.pictureRepository.GetById(id);

            this.pictureRepository.Delete(model);
        }

        public void DeleteModels(IEnumerable<Picture> list)
        {
            this.pictureRepository.Delete(list);
        }

        public Picture GetModel(int id)
        {
            return this.pictureRepository.GetById(id);
        }
    }
}
