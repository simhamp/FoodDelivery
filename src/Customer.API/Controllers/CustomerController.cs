using Customer.Application.Features.Commands.DeleteCustomer;
using Customer.Application.Features.Commands.SaveCustomer;
using Customer.Application.Features.Commands.UpdateCustomer;
using Customer.Application.Features.Queries.CustomerListQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly IMediator _mediator;

    public CustomerController(IMediator medaitor)
    {
      _mediator = medaitor ?? throw new ArgumentNullException(nameof(medaitor));
    }

    [HttpGet("{userName}", Name = "GetOrder")]
    [ProducesResponseType(typeof(IEnumerable<CustomerVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CustomerVm>>> GetOrdersByUserName()
    {
      var query = new CustomerListQuery();
      var orders = await _mediator.Send(query);
      return Ok(orders);
    }

    [HttpPost(Name = "SaveCustomer")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveCustomer([FromBody] SaveCustomerCommand command)
    {
      var result = await _mediator.Send(command);
      return Ok(result);
    }

    [HttpPut(Name = "UpdateCustomer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
    {
      await _mediator.Send(command);
      return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCustomer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
      var command = new DeleteCustomerCommand() { Id = id };
      await _mediator.Send(command);
      return NoContent();
    }

  }
}
