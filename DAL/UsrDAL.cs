using MrBin.Models;
using static MrBin.Models.Usr;
using Microsoft.Data.SqlClient;
namespace MrBin.DAL;

public class UsrDAL
{
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
    public async Task<bool> checkSameEmail(string email)
    {
        sqlCommand = new SqlCommand("select count(*) from Usr where UEmail=@UEMail", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@UEmail", email);
        try
        {
            sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            int count = 0;
            if (await sqlDataReader.ReadAsync())
            {
                count = Convert.ToInt32(sqlDataReader[0].ToString());
                Console.WriteLine($"Count of users with email {email}: {count}");
            }
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            throw;
        }
        finally
        {
            sqlDataReader?.Close();
            sqlCommand.Dispose();
        }
    }
    public async Task registerUser(Usr usr)
    {
        sqlCommand = new SqlCommand("insert into Usr (UFname, ULname, ZipCode, UEmail, UProfileImage, UPassword) values (@UFname, @ULname, @ZipCode, @UEmail, @UProfileImage, @UPassword)", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@UFname", usr.UFname);
        sqlCommand.Parameters.AddWithValue("@ULname", usr.ULname);
        sqlCommand.Parameters.AddWithValue("@ZipCode", usr.ZipCode);
        sqlCommand.Parameters.AddWithValue("@UEmail", usr.UEmail);
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
    ~UsrDAL()
    {
        sqlConnection.Close();
        sqlConnection.Dispose();    
    }
}
