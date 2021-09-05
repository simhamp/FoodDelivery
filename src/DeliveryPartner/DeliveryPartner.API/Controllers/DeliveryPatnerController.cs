using DeliveryPartner.API.Entities;
using DeliveryPartner.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Controllers
{

  [ApiController]
  [Route("api/v1/[controller]")]
  public class DeliveryPatnerController : ControllerBase
  {

    private readonly IDeliveryPartnerRepository _repository;
    private readonly ILogger<DeliveryPatnerController> _logger;

    public DeliveryPatnerController(IDeliveryPartnerRepository repository, ILogger<DeliveryPatnerController> logger)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    [Route("[action]/{userName}", Name = "GetProfileByUserName")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DeliveryPartnerProfile>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DeliveryPartnerProfile>>> GetProfileByUserName(string userName)
    {
      var menus = await _repository.GetProfileByUserName(userName);
      return Ok(menus);
    }

    [HttpGet("{id:length(24)}", Name = "GetProfile")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(DeliveryPartnerProfile), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeliveryPartnerProfile>> GetProfileById(string id)
    {
      var menu = await _repository.GetProfile(id);
      if (menu == null)
      {
        _logger.LogError($"Menu with id: {id}, not found.");
        return NotFound();
      }
      return Ok(menu);
    }


    [HttpPost(Name = "CreateProfile")]
    [ProducesResponseType(typeof(DeliveryPartnerProfile), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeliveryPartnerProfile>> CreateProfile([FromBody] DeliveryPartnerProfile profile)
    {
      await _repository.CreateProfile(profile);

      return CreatedAtRoute("GetProfile", new { id = profile.Id }, profile);
    }
    [HttpPut(Name = "UpdateProfile")]    
    [ProducesResponseType(typeof(DeliveryPartnerProfile), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProfile([FromBody] DeliveryPartnerProfile profile)
    {
      return Ok(await _repository.UpdateProfile(profile));
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteProfile")]
    [ProducesResponseType(typeof(DeliveryPartnerProfile), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProfileById(string id)
    {
      return Ok(await _repository.DeleteProfile(id));
    }

  }
}
