using MrBin.Models;
using static MrBin.Models.Usr;
using Microsoft.Data.SqlClient;
namespace MrBin.DAL;
public class UsrDAL{
    private readonly string _connectionString;
    private readonly SqlConnection sqlConnection;
    private SqlCommand sqlCommand;
    private SqlDataReader sqlDataReader;
    public UsrDAL(string connectionString)
    {
        _connectionString = connectionString;
        sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();
    }
    public async Task registerUser(Usr usr)
    {
        sqlCommand = new SqlCommand("insert into Usr (UFname, ULname, ZipCode, UEmail, UProfileImage, UPassword) values (@UFname, @ULname, @ZipCode, @UEmail, @UProfileImage, @UPassword)", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@UFname", usr.UFname);
        sqlCommand.Parameters.AddWithValue("@ULname", usr.ULname);
        sqlCommand.Parameters.AddWithValue("@ZipCode", usr.ZipCode);
        sqlCommand.Parameters.AddWithValue("@UEmail", usr.UEmail);

        // Ensure UProfileImage is a byte array for varbinary(max) columns
        if (usr.UProfileImage != null)
        {
            sqlCommand.Parameters.Add("@UProfileImage", System.Data.SqlDbType.VarBinary).Value = usr.UProfileImage;
        }
        else
        {
            sqlCommand.Parameters.Add("@UProfileImage", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
        }

        sqlCommand.Parameters.AddWithValue("@UPassword", usr.UPassword);
        try
        {
            await sqlCommand.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            throw;
        }
        finally
        {
            sqlCommand.Dispose();
            
        }
    }
}
