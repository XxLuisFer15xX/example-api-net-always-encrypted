using EXAMPLE_API.Entities.Config;
using EXAMPLE_API.Entities.Response;
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

        public async Task<Payload> gestion(
            Languages lng,
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
            var payload = new Payload();
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
                                payload.Data.Add(row);
                            }
                        }

                        // Obtener valores de los parámetros de salida
                        var pcResult = pcResultParam.Value as string;
                        payload.TypeResult = (int)pnTypeResultParam.Value;
                        payload.Message = lng[pcResult].ToString();
                        payload.Result = pcMessageParam.Value as string;
                    }
                }
            }
            catch (Exception ex)
            {
                payload.TypeResult = 2;
                payload.Message = ex.Message;
                payload.Result = "Error";
                payload.Data = null;
            }

            return payload;
        }
    }
}
