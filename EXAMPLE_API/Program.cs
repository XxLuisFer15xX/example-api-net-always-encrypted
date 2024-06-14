using EXAMPLE_API.Services;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
using Microsoft.Data.SqlClient;
using EXAMPLE_API.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Key Vault Config
builder.Services.Configure<KeyVaultConfig>(builder.Configuration.GetSection("KeyVaultConfig"));
var keyVaultConfig = builder.Configuration.GetSection("KeyVaultConfig").Get<KeyVaultConfig>();
KeyVaultSetup.ClientId = keyVaultConfig.AkvClientId;
KeyVaultSetup.ClientSecretId = keyVaultConfig.AkvClientSecretId;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialize AKV provider
SqlColumnEncryptionAzureKeyVaultProvider sqlColumnEncryptionAzureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(KeyVaultSetup.AzureActiveDirectoryAuthenticationCallback);

// Register AKV provider
SqlConnection.RegisterColumnEncryptionKeyStoreProviders(customProviders: new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>(capacity: 1, comparer: StringComparer.OrdinalIgnoreCase)
{
    { SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, sqlColumnEncryptionAzureKeyVaultProvider}
});

app.Run();
