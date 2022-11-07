using Application.Client.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientLogic clientLogic;

    public ClientController(IClientLogic clientLogic)
    {
        this.clientLogic = clientLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> CreateAsync(ClientCreationDTO dto)
    {
        try
        {
            Client client = await clientLogic.CreateAsync(dto);
            return Created($"clients/{client.id}", client);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}