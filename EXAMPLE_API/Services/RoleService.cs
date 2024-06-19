using EXAMPLE_API.Entities.Config;
using EXAMPLE_API.Entities.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EXAMPLE_API.Services
{
    public class RoleService
    {
        private readonly string _connectionString;

        public RoleService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Payload> gestion(
            Languages lng,
            int pnTipoOperacion,
            string pcUser,
            int? pnIdRole = null,
            string? pcName = null,
            string? pcDescription = null,
            int? pnStatus = null
        )
        {
            var payload= new Payload();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[sp_roles]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.Add(new SqlParameter("@pnTipoOperacion", pnTipoOperacion));
                        command.Parameters.Add(new SqlParameter("@pcUser", pcUser));
                        command.Parameters.Add(new SqlParameter("@pnIdRole", pnIdRole ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@pcName", pcName ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@pcDescription", pcDescription ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@pnStatus", pnStatus ?? (object)DBNull.Value));

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
