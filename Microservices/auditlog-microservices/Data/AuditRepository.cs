using HRServicesAPI.Entities;
using HRServicesAPI.Dto;

namespace HRServicesAPI.Data
{
    public interface IAuditRepository
    {
        List<Audit> GetAll(QueryParams query);
        Task<Audit?> Add(Audit audit);
    }

    public class AuditRepository : IAuditRepository
    {
        private readonly DatabaseContext _dbContext;

        public AuditRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }


        public async Task<Audit?> Add(Audit audit)
        {
            _dbContext.Audits.Add(audit);

            await _dbContext.SaveChangesAsync();

            return audit;
        }

        public List<Audit> GetAll(QueryParams query)
        {
            // var audits =   _dbContext.Audits.ToList();
            // return audits;

            var queryResult = _dbContext.Audits.AsQueryable();
            if (!string.IsNullOrEmpty(query.search)) {
                queryResult = queryResult.Where(e => e.Detail.Contains(query.search));
            }

            if (!string.IsNullOrEmpty(query.module)) {
                queryResult = queryResult.Where(e => e.Module.Equals(query.module));
            }

            var result = queryResult.ToList();
            return result;
        }

    }
}
