﻿using REMS.Models.Property;

namespace REMS.BackendApi.Features.Property;

[Route("api/v1/properties")]
[ApiController]
public class PropertyController : ControllerBase
{
    private readonly BL_Property _blProperties;

    public PropertyController(BL_Property blProperties)
    {
        _blProperties = blProperties;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties()
    {
        try
        {
            var response = await _blProperties.GetProperties();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetProperties(int pageNo, int pageSize)
    {
        try
        {
            var response = await _blProperties.GetProperties(pageNo, pageSize);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{propertyId}")]
    public async Task<IActionResult> GetPropertyById(int propertyId)
    {
        try
        {
            var response = await _blProperties.GetPropertyById(propertyId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty([FromBody] PropertyRequestModel requestModel)
    {
        if (requestModel == null)
        {
            return BadRequest("Request model cannot be null");
        }

        try
        {
            var response = await _blProperties.CreateProperty(requestModel);
            return CreatedAtAction(nameof(GetPropertyById), new { propertyId = response.Property.PropertyId }, response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{propertyId}")]
    public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] PropertyRequestModel requestModel)
    {
        if (propertyId < 1)
        {
            return BadRequest("Invalid Property Id");
        }

        if (requestModel == null)
        {
            return BadRequest("Request model cannot be null");
        }

        try
        {
            var response = await _blProperties.UpdateProperty(propertyId, requestModel);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{propertyId}")]
    public async Task<IActionResult> DeleteProperty(int propertyId)
    {
        if (propertyId < 1)
        {
            return BadRequest("Invalid Property Id");
        }

        try
        {
            var result = await _blProperties.DeleteProperty(propertyId);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Property not found");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}