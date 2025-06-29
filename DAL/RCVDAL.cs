namespace MrBin.DAL
{
    public class RCVDAL
    {
        private readonly IConfiguration _configuration;

        public RCVDAL(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            if (_configuration.GetConnectionString("DB") == null)
            {
                throw new ArgumentNullException(nameof(configuration), "DB connection string is missing.");
            }
        }
        
    }
}