﻿using Azure;
using REMS.Database.AppDbContextModels;
using REMS.Modules.Features.Agent;

namespace REMS.BackendApi.Features.Client;

[Route("api/v1/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly BL_Client _blClient;

    public ClientController(BL_Client blClient)
    {
        _blClient = blClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        try
        {
            var responseModel = await _blClient.GetClients();
            return Ok(responseModel);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpGet("{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetClients(int pageNo, int pageSize)
    {
        try
        {
            var response = await _blClient.GetClients(pageNo, pageSize);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(int id)
    {
        try
        {
            var responseModel = await _blClient.GetClientById(id);
            return Ok(responseModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostClient(ClientRequestModel requestModel)
    {
        try
        {
            var response = await _blClient.CreateClientAsync(requestModel);
            if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateClient(int id, ClientRequestModel requestModel)
    {
        try
        {
            var response = await _blClient.UpdateClientAsync(id, requestModel);
            if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            var response = await _blClient.DeleteClientAsync(id);
            if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }
}
