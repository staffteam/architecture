using AutoMapper;
using YH.Framework.Core.Domain.Configuration;
using YH.Framework.Core.Domain.Navigates;
using YH.Framework.Web.Areas.CmsAdmin.Models;
using YH.Framework.Web.Areas.CmsAdmin.Models.Navigates;
using System.Linq;
using System;

namespace YH.Framework.Web.Areas.CmsAdmin.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        private readonly string MvcViewModelClassSuffixName = "Model";

        public AutoMapperProfile()
        {
            var modelTypes = this.GetType().Assembly.GetTypes().Where(t => t.Name.EndsWith(MvcViewModelClassSuffixName));

            var domainTypes = typeof(YH.Framework.Core.Domain.Common.BaseEntity).Assembly.GetTypes();

            foreach (Type modelType in modelTypes)
            {
                var modelTypeRelateDomainType = domainTypes.SingleOrDefault(domainType => domainType.Name + MvcViewModelClassSuffixName == modelType.Name);
                if (modelTypeRelateDomainType != null)
                {
                    this.CreateMap(modelType, modelTypeRelateDomainType);
                    this.CreateMap(modelTypeRelateDomainType, modelType).MaxDepth(10);
                }
            }
        }
    }
}