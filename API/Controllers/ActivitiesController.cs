using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // private readonly DataContext _context;
        // here we brought in the IMediator here
    
        // private readonly IMediator _mediator;

        // public ActivitiesController(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct){
            // return await _context.Activities.ToListAsync();   
            return await Mediator.Send(new List.Query(), ct);
        }


        [HttpGet("{id}")] //activites//id
        public async Task <ActionResult<Activity>> GetActivity(Guid id){
            // return await _context.Activities.FindAsync(id);
            // return Ok();
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        //IACTIONRESULT do ok,bad reuqestion jobs
        public async Task<IActionResult> CreateActivity([FromBody]Activity activity){
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id){
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}