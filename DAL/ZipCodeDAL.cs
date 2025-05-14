using Models;
using Microsoft.Data.SqlClient;
namespace DAL{
    public class ZipCodeDAL{
        private readonly string _connectionString;
        public ZipCodeDAL(string _connectionString)
        {
            this._connectionString = _connectionString;
        }
        public async Task<List<ZipCode>> GetAllZipCode(string DistId){
            SqlConnection conn=new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd=new SqlCommand("select * from ZipCode where DistId='"+DistId+"';",conn);
            List<ZipCode> zipCodes=new List<ZipCode>();
            SqlDataReader sqlDataReader=await cmd.ExecuteReaderAsync();
            while(await sqlDataReader.ReadAsync()){
                ZipCode zc=new ZipCode{
                    ZId=Convert.ToInt32(sqlDataReader[0].ToString()),
                    ZCode=sqlDataReader[1].ToString(),
                    DistId=sqlDataReader[2].ToString(),
                    AreaName=sqlDataReader[3].ToString()
                };
                zipCodes.Add(zc);
            }
            return zipCodes;
        }
    }
}