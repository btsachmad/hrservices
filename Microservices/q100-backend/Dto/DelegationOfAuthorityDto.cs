namespace HRServicesAPI.Dto;

public class DelegationOfAuthorityDto
{
    public Guid Id { get; set; }
    
    public Guid IdEmployee { get; set; }

    public string NikEmployee { get; set; }

    public string NikDelegationEmployee { get; set; }

    public Guid IdDelegationEmployee { get; set; }

}