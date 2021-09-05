using FoodPartner.API.Entities;
using FoodPartner.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FoodPartner.API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class FoodPartnerController : ControllerBase
  {
    private readonly IFoodPartnerRepository _repository;
    private readonly ILogger<FoodPartnerController> _logger;

    public FoodPartnerController(IFoodPartnerRepository repository, ILogger<FoodPartnerController> logger)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    [Route("[action]/{userName}", Name = "GetMenuByUserName")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Menu>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Menu>>> GetMenuByUserName(string userName)
    {
      var menus = await _repository.GetMenuByUserName(userName);
      return Ok(menus);
    }

    [HttpGet("{id:length(24)}", Name = "GetMenu")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Menu>> GetMenuById(string id)
    {
      var menu = await _repository.GetMenu(id);
      if (menu == null)
      {
        _logger.LogError($"Menu with id: {id}, not found.");
        return NotFound();
      }
      return Ok(menu);
    }


    [HttpPost(Name = "CreateMenu")]
    [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Menu>> CreateMenu([FromBody] Menu menu)
    {
      await _repository.CreateMenu(menu);

      return CreatedAtRoute("GetMenu", new { id = menu.Id }, menu);
    }

    [HttpPut(Name = "UpdateMenu")]
    [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateMenu([FromBody] Menu menu)
    {
      return Ok(await _repository.UpdateMenu(menu));
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteMenu")]
    [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteMenuById(string id)
    {
      return Ok(await _repository.DeleteMenu(id));
    }
  }
}
