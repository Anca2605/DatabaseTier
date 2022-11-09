using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models;

public class Client{
    [Key]
    [JsonPropertyName("id")]
    
    public string Username { get; set; }
    public string password { get; set; }
    
}