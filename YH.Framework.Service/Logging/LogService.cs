using System;
using System.Linq;
using YH.Framework.Core.Data;
using YH.Framework.Core.Domain.Logging;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Logging
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> logRepository;

        public LogService(IRepository<Log> logRepository)
        {
            this.logRepository = logRepository;
        }

        public void CreateLog(Log log)
        {
            logRepository.Insert(log);
        }

        public IPagedList<Log> GetLogs(DateTime? startDate = null, DateTime? endDate = null, string severity = null, int pageNumber = 1, int pageSize = sbyte.MaxValue)
        {
            var logs = logRepository.Table;

            if (startDate.HasValue)
            {
                logs = logs.Where(log => log.Timestamp >= startDate);
            }

            if (endDate.HasValue)
            {
                logs = logs.Where(log => log.Timestamp <= endDate);
            }

            if (!string.IsNullOrWhiteSpace(severity))
            {
                logs = logs.Where(m => m.Severity == severity);
            }

            return logs.OrderByDescending(log => log.Timestamp).ToPagedList(pageNumber, pageSize);
        }

        public void DeleteLog(int id)
        {
            logRepository.Delete(logRepository.GetById(id));
        }

        public Log GetLog(int id)
        {
            return logRepository.GetById(id);
        }

        public void ClearLogs(DateTime? startDate = null, DateTime? endDate = null, string severity = null)
        {
            var logs = logRepository.Table;

            if (startDate.HasValue)
            {
                logs = logs.Where(log => log.Timestamp >= startDate);
            }

            if (endDate.HasValue)
            {
                logs = logs.Where(log => log.Timestamp <= endDate);
            }

            if (!string.IsNullOrWhiteSpace(severity))
            {
                logs = logs.Where(m => m.Severity == severity);
            }

            logRepository.Delete(logs);
        }
    }
}
