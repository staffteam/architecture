using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Navigates;

namespace YH.Framework.Service.Navigates
{
    public interface INavigateService
    {
        void CreateNavigate(Navigate navigate);

        Navigate GetNavigate(int id);

        List<Navigate> GetNavigates();

        void Delete(int id);

        void Update(Navigate navigate);
    }
}
