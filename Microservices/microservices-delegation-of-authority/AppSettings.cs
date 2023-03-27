namespace HRServicesAPI
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int IterationCount { get; set; }
        public string PasscodeKey { get; set; }
    }
}
