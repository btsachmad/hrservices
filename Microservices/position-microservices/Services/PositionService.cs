using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Data;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{
    public interface IPositionService
    {
        List<Position> GetAll();
        Task<Position?> GetDetail(Guid id);
        Task<Position?> Add(PositionRequest position);
        Task<Position?> Update(Guid id, PositionRequest position);
        Task<Position?> Activate(Guid id);
        Task<Position?> Deactivate(Guid id);
    }

    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepo;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository userRepository, IMapper mapper)
        {
            _positionRepo = userRepository;
            _mapper = mapper;
        }

        public async Task<Position?> Activate(Guid id)
        {
            return await _positionRepo.Activate(id);
        }

        public async Task<Position?> Add(PositionRequest request)
        {
            var position = _mapper.Map<Position>(request);
            return await _positionRepo.Add(position);
        }

        public async Task<Position?> Deactivate(Guid id)
        {
            // TODO : Check is used by user
            return await _positionRepo.Deactivate(id);
        }

        public List<Position> GetAll()
        {
            return _positionRepo.GetAll();
        }

        public async Task<Position?> GetDetail(Guid id)
        {
            return await _positionRepo.GetDetail(id);
        }

        public async Task<Position?> Update(Guid id, PositionRequest request)
        {
            var position = _mapper.Map<Position>(request);
            return await _positionRepo.Update(id, position);
        }
    }
}
