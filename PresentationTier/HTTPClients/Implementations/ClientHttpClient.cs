using System.Net.Http.Json;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.Implementations;

public class ClientHttpClient : IClientService
{
    private readonly HttpClient httpClient;

    public ClientHttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Client> Create(ClientCreationDTO dto)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/clients", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Client client = JsonSerializer.Deserialize<Client>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return client;
    }
}