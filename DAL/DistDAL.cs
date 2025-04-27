using Models;
using Microsoft.Data.SqlClient;
namespace DAL{
    public class DistDAL{
        private readonly string _connectionString;
        public DistDAL(string _connectionString)
        {
            this._connectionString = _connectionString;
        }
        public async Task<List<Dist>> GetAllState(string Stateid){
            SqlConnection conn=new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd=new SqlCommand("select * from Dist where Stateid='"+Stateid+"';",conn);
            List<Dist> dists=new List<Dist>();
            SqlDataReader sqlDataReader=await cmd.ExecuteReaderAsync();
            while(await sqlDataReader.ReadAsync()){
                Dist dt=new Dist{
                    DistId=sqlDataReader[0].ToString(),
                    DistName=sqlDataReader[1].ToString(),
                    StateId=sqlDataReader[2].ToString()
                };
                dists.Add(dt);
            }
            return dists;
        }
    }
}