using FoodOrdering.API.Entities;
using FoodOrdering.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FoodOrdering.API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class FoodOrderController : ControllerBase
  {

    private readonly IOrderRepository _repository;
    private readonly ILogger<FoodOrderController> _logger;
    public FoodOrderController(IOrderRepository foodOrderRepository, ILogger<FoodOrderController> logger)
    {
      _repository = foodOrderRepository;
      _logger = logger;
    }

    [HttpGet("{userName}", Name = "GetOrdersByUserName")]
    [ProducesResponseType(typeof(IEnumerable<FoodOrder>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<FoodOrder>>> GetOrdersByUserName(string userName)
    {
      var result = await _repository.GetOrdersByUserName(userName);
      return Ok(result);
    }

    [HttpPost(Name = "SaveFoodOrder")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveFoodOrder([FromBody] FoodOrder order)
    {
      await _repository.AddAsync(order);
      
      return Ok();
    }
    

    [HttpDelete("{id}", Name = "DeleteFoodOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteFoodOrder(int id)
    {
      await _repository.DeleteAsync(id);
      return NoContent();
    }
  }
}
