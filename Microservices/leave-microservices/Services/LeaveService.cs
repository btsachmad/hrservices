using AutoMapper;
using HRServicesAPI.Data;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{
    public interface ILeaveService
    {
        Task<ResponsePaginationDTO<LeaveRead>> GetListByNik(Guid IdEmployee, string? search, int? page, int? pageSize);
        Task<ResponsePaginationDTO<LeaveRead>> GetListByReviewer(int level, string? search, int? page, int? pageSize);
        Task<Leave> Create(LeaveCreate payload);
        Task<Leave> Approve(LeaveApprove payload);
        Task<Leave> Reject(LeaveReject payload);
    }

    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepo;
        private readonly IMapper _mapper;

        public LeaveService(ILeaveRepository leaveRepository, IMapper mapper)
        {
            _leaveRepo = leaveRepository;
            _mapper = mapper;
        }

        public async Task<ResponsePaginationDTO<LeaveRead>> GetListByNik(
            Guid IdEmployee,
            string? search,
            int? page,
            int? pageSize
        )
        {
            var skipAmount = pageSize * (page - 1);
            var data = await _leaveRepo.GetListByNik(IdEmployee, search, pageSize ?? 10, skipAmount ?? 1);
            var count = await _leaveRepo.CountAll();

            var response = _mapper.Map<List<LeaveRead>>(data);

            var mod = count % pageSize;
            var totalPage = (count / pageSize) + (mod == 0 ? 0 : 1);

            return new ResponsePaginationDTO<LeaveRead>()
            {
                PageSize = pageSize,
                PageNumber = page,
                Results = response,
                TotalNumberOfPages = totalPage,
                TotalNumberOfRecords = count
            };
        }

        public async Task<ResponsePaginationDTO<LeaveRead>> GetListByReviewer(
            int level,
            string? search,
            int? page,
            int? pageSize
        )
        {
            var skipAmount = pageSize * (page - 1);
            var data = await _leaveRepo.GetListByReviewer(level, search, pageSize ?? 10, skipAmount ?? 1);
            var count = await _leaveRepo.CountAll();

            var response = _mapper.Map<List<LeaveRead>>(data);

            var mod = count % pageSize;
            var totalPage = (count / pageSize) + (mod == 0 ? 0 : 1);

            return new ResponsePaginationDTO<LeaveRead>()
            {
                PageSize = pageSize,
                PageNumber = page,
                Results = response,
                TotalNumberOfPages = totalPage,
                TotalNumberOfRecords = count
            };
        }

        public Task<Leave> Create(LeaveCreate payload)
        {
            return _leaveRepo.Create(payload);
        }

        public Task<Leave> Approve(LeaveApprove payload)
        {
            return _leaveRepo.Approve(payload);
        }

        public Task<Leave> Reject(LeaveReject payload)
        {
            return _leaveRepo.Reject(payload);
        }
    }
}
