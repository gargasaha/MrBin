using Models;
using Microsoft.Data.SqlClient;
using MrBin.Models;
namespace DAL{
    public class StateDAL{
        private readonly string _connectionString;
        public StateDAL(string _connectionString)
        {
            this._connectionString = _connectionString;
        }
        public async Task<List<State>> GetAllState(){
            SqlConnection conn=new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd=new SqlCommand("select * from State",conn);
            List<State> states=new List<State>();
            SqlDataReader sqlDataReader=await cmd.ExecuteReaderAsync();
            while(await sqlDataReader.ReadAsync()){
                State st=new State{
                    StateId=sqlDataReader[0].ToString(),
                    StateName=sqlDataReader[1].ToString()
                };
                states.Add(st);
            }
            return states;
        }
    }
}