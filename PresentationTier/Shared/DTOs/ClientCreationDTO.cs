namespace Shared.DTOs;

public class ClientCreationDTO
{
    public string username { get; }
    public string password { get; }

    public ClientCreationDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}