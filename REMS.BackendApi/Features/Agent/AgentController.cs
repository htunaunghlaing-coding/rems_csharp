﻿namespace REMS.BackendApi.Features.Agent;

[Route("api/v1/agents")]
[ApiController]
public class AgentController : ControllerBase
{
    private readonly BL_Agent _blAgent;

    public AgentController(BL_Agent blAgent)
    {
        _blAgent = blAgent;
    }

    [HttpPost]
    public async Task<IActionResult> PostAgent(AgentRequestModel requestModel)
    {
        try
        {
            var response = await _blAgent.CreateAgentAsync(requestModel);
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

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteAgent(int userId)
    {
        try
        {
            var response = await _blAgent.DeleteAgentAsync(userId);
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
    public async Task<IActionResult> UpdateAgent(int id, AgentRequestModel requestModel)
    {
        try
        {
            var response = await _blAgent.UpdateAgentAsync(id, requestModel);
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

    [HttpPost("LoginAgent", Name = "LoginAgent")]
    public async Task<IActionResult> LoginAgent(AgentLoginRequestModel agentLoginInfo)
    {
        MessageResponseModel agentList = await _blAgent.LoginAgentAsync(agentLoginInfo);

        return Ok(agentList);
    }

    [HttpGet("SearchUser/{id}", Name = "SearchUser")]
    public async Task<IActionResult> SearchUser(int id)
    {
        AgentResponseModel agentList = await _blAgent.SearchAgentAsync(id);

        return Ok(agentList);
    }

    [HttpGet("SearchUserByName/{name}/{pageNumber}/{pageSize}", Name = "SearchUserByName")]
    public async Task<IActionResult> SearchUserByName(string name,int pageNumber,int pageSize)
    {
        AgentListResponseModel agentList = await _blAgent.SearchAgentByNameAsync(name, pageNumber, pageSize);

        return Ok(agentList);
    }

    [HttpPost("SearchAgentByNameAndLocation", Name = "SearchAgentByNameAndLocation")]
    public async Task<IActionResult> SearchAgentByNameAndLocation(SearchAgentRequestModel _searchAgentReqeustModel)
    {
        AgentListResponseModel agentList = await _blAgent.SearchAgentByNameAndLocationAsync(_searchAgentReqeustModel);

        return Ok(agentList);
    }
}