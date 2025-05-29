using MrBin.Models;
using static MrBin.Models.Usr;
using Microsoft.Data.SqlClient;
namespace MrBin.DAL;
public class UsrDAL{
    private readonly string _connectionString;
    public UsrDAL(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<List<Usr>> GetAll(){
        SqlConnection connection = new SqlConnection(_connectionString);
        List<Usr> usrs = new List<Usr>();
        SqlCommand command = new SqlCommand("SELECT * FROM Usr", connection);
        await connection.OpenAsync();
        SqlDataReader reader = await command.ExecuteReaderAsync();
        while(await reader.ReadAsync()){
            Usr usr = new Usr();
            usr.UserId =reader[0].ToString();
            usr.UserName = reader[1].ToString();
            usr.UserStateId = null;
            usr.UserDistId = null;
            usr.UserProfileImage = null;
            usr.Password = null;
            usrs.Add(usr);
        }
        connection.Close();
        connection.Dispose();
        reader.Close();
        reader.Dispose();
        command.Dispose();
        
        return usrs;
    }
}
