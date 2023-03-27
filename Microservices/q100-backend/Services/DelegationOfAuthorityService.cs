using AutoMapper;
using HRServicesAPI.Data;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{
    public interface IDelegationOfAuthorityService
    {
        List<DelegationOfAuthorityDto> GetAllDelegationOfAuthority();

        DelegationOfAuthorityDto CreateDelegationOfAuthority(DelegationOfAuthorityDto input);

        List<DelegationOfAuthorityDto> GetDelegationOfAuthorityByNik(string nik);

        DelegationOfAuthorityDto UpdateDelegationOfAuthority(DelegationOfAuthorityDto input);
    }

    public class DelegationOfAuthorityService : IDelegationOfAuthorityService
    {
        private readonly IDelegationOfAuthorityRepository _delegationOfAuthorityRepository;
        private readonly IMapper _mapper;

        public DelegationOfAuthorityService(IDelegationOfAuthorityRepository delegationOfAuthorityRepository,
            IMapper mapper)
        {
            _delegationOfAuthorityRepository = delegationOfAuthorityRepository;
            _mapper = mapper;
        }

        public List<DelegationOfAuthorityDto> GetAllDelegationOfAuthority()
        {
            var delegationOfAuthorities = _delegationOfAuthorityRepository.GetAllDelegationOfAuthority();
            
            List<DelegationOfAuthorityDto> result = new List<DelegationOfAuthorityDto>();
            foreach (var delegationOfAuthority in delegationOfAuthorities)
            {
                result.Add(_mapper.Map<DelegationOfAuthorityDto>(delegationOfAuthority));
            }

            return result;
        }

        public DelegationOfAuthorityDto CreateDelegationOfAuthority(DelegationOfAuthorityDto input)
        {
            var tmpInput = _mapper.Map<DelegationOfAuthority>(input);

            var delegationOfAuthority = _delegationOfAuthorityRepository.CreateDelegationOfAuthority(tmpInput);

            var result = _mapper.Map<DelegationOfAuthorityDto>(delegationOfAuthority);

            return result;

        }

        public List<DelegationOfAuthorityDto> GetDelegationOfAuthorityByNik(string nik)
        {
            var delegationOfAuthorities = _delegationOfAuthorityRepository.GetDelegationOfAuthorityByNik(nik);

            List<DelegationOfAuthorityDto> result = new List<DelegationOfAuthorityDto>();
            foreach (var delegationOfAuthority in delegationOfAuthorities)
            {
                result.Add(_mapper.Map<DelegationOfAuthorityDto>(delegationOfAuthority));
            }

            return result;
        }

        public DelegationOfAuthorityDto UpdateDelegationOfAuthority(DelegationOfAuthorityDto input)
        {
            var tmpInput = _mapper.Map<DelegationOfAuthority>(input);
            var delegationOfAuthority = _delegationOfAuthorityRepository.UpdateDelegationOfAuthority(tmpInput);

            var result = _mapper.Map<DelegationOfAuthorityDto>(delegationOfAuthority);

            return result;
        }
    }
}        