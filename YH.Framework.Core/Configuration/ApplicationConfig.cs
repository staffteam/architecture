using System.Configuration;

namespace YH.Framework.Core.Configuration
{
    public class ApplicationConfig : ConfigurationSection
    {
        private const string RedisCacheConfigPropertyName = "redisCache";

        [ConfigurationProperty(RedisCacheConfigPropertyName)]
        public RedisCacheElement RedisCacheConfig
        {
            get { return (RedisCacheElement)base[RedisCacheConfigPropertyName]; }
            set { base[RedisCacheConfigPropertyName] = value; }
        }
    }
}
