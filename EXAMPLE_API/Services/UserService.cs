using Microsoft.Data.SqlClient;
using System.Data;

namespace EXAMPLE_API.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<UserResult> gestion(
            int pnTipoOperacion,
            string pcUser,
            int? pnIdUser = null,
            string? pcFirstName = null,
            string? pcLastName = null,
            string? pcEmail = null,
            DateTime? pdBirthdate = null,
            int? pnIdRole = null,
            int? pnStatus = null
        )
        {
            var userResult = new UserResult();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[sp_users]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.Add(new SqlParameter("@pnTipoOperacion", pnTipoOperacion));
                        command.Parameters.Add(new SqlParameter("@pcUser", pcUser));
                        command.Parameters.Add(new SqlParameter("@pnIdUser", pnIdUser));
                        command.Parameters.Add(new SqlParameter("@pcFirstName", SqlDbType.VarChar, 100) { Value = pcFirstName });
                        command.Parameters.Add(new SqlParameter("@pcLastName", SqlDbType.VarChar, 100) { Value = pcLastName });
                        command.Parameters.Add(new SqlParameter("@pcEmail", pcEmail));
                        command.Parameters.Add(new SqlParameter("@pdBirthdate", SqlDbType.DateTime, int.MaxValue) { Value = pdBirthdate });
                        command.Parameters.Add(new SqlParameter("@pnIdRole", pnIdRole));
                        command.Parameters.Add(new SqlParameter("@pnStatus", pnStatus));

                        // Parámetros de salida
                        var pnTypeResultParam = new SqlParameter("@pnTypeResult", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        var pcResultParam = new SqlParameter("@pcResult", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                        var pcMessageParam = new SqlParameter("@pcMessage", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };

                        command.Parameters.Add(pnTypeResultParam);
                        command.Parameters.Add(pcResultParam);
                        command.Parameters.Add(pcMessageParam);

                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                userResult.Data.Add(row);
                            }
                        }

                        // Obtener valores de los parámetros de salida
                        userResult.TypeResult = (int)pnTypeResultParam.Value;
                        userResult.Result = pcResultParam.Value as string;
                        userResult.Message = pcMessageParam.Value as string;
                    }
                }
            }
            catch (Exception ex)
            {
                userResult.TypeResult = 2;
                userResult.Result = "ERROR";
                userResult.Message = ex.Message;
            }

            return userResult;
        }
    }

    public class UserResult
    {
        public int TypeResult { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public List<Dictionary<string, object>> Data { get; set; } = new List<Dictionary<string, object>>();
    }
}
