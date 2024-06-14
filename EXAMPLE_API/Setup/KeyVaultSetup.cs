using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace EXAMPLE_API.Setup
{
    public static class KeyVaultSetup
    {
        public static string ClientId { get; set; }
        public static string ClientSecretId { get; set; }

        public static async Task<string> AzureActiveDirectoryAuthenticationCallback(string authority, string resource, string scope)
        {
            Console.WriteLine(ClientId, ClientSecretId);
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(ClientId, ClientSecretId);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
            if (result == null)
            {
                throw new InvalidOperationException($"Failed to retrieve an access token for {resource}");
            }

            return result.AccessToken;
        }
    }
}
