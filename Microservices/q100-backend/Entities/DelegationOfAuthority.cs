namespace HRServicesAPI.Entities;

public class DelegationOfAuthority : Base
{
    public string NikDelegationEmployee { get; set; }

    public Guid IDDelegationEmployee { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
}