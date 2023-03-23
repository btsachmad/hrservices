using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Data;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{
    public interface IAuditService
    {
        List<Audit> GetAll(QueryParams query);
        Task<Audit?> Add(AuditRequest audit);
    }

    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepo;
        private readonly IMapper _mapper;

        public AuditService(IAuditRepository userRepository, IMapper mapper)
        {
            _auditRepo = userRepository;
            _mapper = mapper;
        }


        public async Task<Audit?> Add(AuditRequest request)
        {
            var audit = _mapper.Map<Audit>(request);
            return await _auditRepo.Add(audit);
        }


        public List<Audit> GetAll(QueryParams query)
        {
            return _auditRepo.GetAll(query);
        }
    }
}
