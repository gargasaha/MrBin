using Microsoft.Data.SqlClient;

namespace MrBin.DAL
{
    public class keyAccessDAL(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public async Task StoreKey(string email, int gkey)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("INSERT INTO Temp (Email, Gkey, Situation) VALUES (@Email, @Gkey, 0);", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Gkey", gkey);
            await cmd.ExecuteNonQueryAsync();
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }

        public async Task<int> GetSituation(string email, int gkey)
        {
            int situation = 0;
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("SELECT Situation FROM Temp WHERE Email=@Email AND Gkey=@Gkey;", conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Gkey", gkey);
                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    situation = Convert.ToInt32(reader[0]);
                }
                cmd.Dispose();

            }
            if (situation == 1)
            {
                using var cmd2 = new SqlCommand("DELETE FROM Temp WHERE Email=@Email AND Gkey=@Gkey;", conn);
                cmd2.Parameters.AddWithValue("@Email", email);
                cmd2.Parameters.AddWithValue("@Gkey", gkey);
                await cmd2.ExecuteNonQueryAsync();
                cmd2.Dispose();
            }
            conn.Close();
            conn.Dispose();
            
            return situation;
        }

        public async Task UpdateKey(string email, int gkey)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("UPDATE Temp SET Situation=1 WHERE Email=@Email AND Gkey=@Gkey;", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Gkey", gkey);
            await cmd.ExecuteNonQueryAsync();
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            
        }
    }
}