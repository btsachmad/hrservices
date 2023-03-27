using HRServicesAPI.Dto;
using HRServicesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRServicesAPI.Data
{
    public interface IDelegationOfAuthorityRepository
    {
        List<DelegationOfAuthority> GetAllDelegationOfAuthority();
        
        DelegationOfAuthority CreateDelegationOfAuthority(DelegationOfAuthority input);
        
        List<DelegationOfAuthority> GetDelegationOfAuthorityByNik(string nik);
        
        DelegationOfAuthority UpdateDelegationOfAuthority(DelegationOfAuthority input);
    }

    public class DelegationOfAuthorityRepository : IDelegationOfAuthorityRepository
    {
        private readonly DatabaseContext _dbContext;

        public DelegationOfAuthorityRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public List<DelegationOfAuthority> GetAllDelegationOfAuthority()
        {
            var result = _dbContext.DelegationOfAuthorities.ToList();

            return result;
        }

        public DelegationOfAuthority CreateDelegationOfAuthority(DelegationOfAuthority input)
        {
            _dbContext.Add(input);
            var result = _dbContext.SaveChanges() == 1;
            return result ? input : null;
        }

        public List<DelegationOfAuthority> GetDelegationOfAuthorityByNik(string nik)
        {
            var result = _dbContext.DelegationOfAuthorities.Where(x => x.NikDelegationEmployee == nik).ToList();
            if (result == null) return null;

            return result;
        }

        public DelegationOfAuthority UpdateDelegationOfAuthority(DelegationOfAuthority input)
        {
            _dbContext.DelegationOfAuthorities.Update(input);
            var result = _dbContext.SaveChanges() == 1;
            return result ? input : null;
        }
    } 
}