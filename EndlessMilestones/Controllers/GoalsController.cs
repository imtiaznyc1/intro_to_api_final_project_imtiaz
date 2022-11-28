using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EndlessMilestones.Models;
using Microsoft.EntityFrameworkCore;

namespace EndlessMilestones.Controllers;

[ApiController]
[Route("[controller]")]
public class GoalsController : ControllerBase
{

    private readonly EndlessMilestonesDbContext _context;

    public GoalsController(EndlessMilestonesDbContext context)
    {
        _context = context;
    }


    // GET: /Goals
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Goals>>> GetGoals()
    //{
    //    return await _context.Goals.ToListAsync();
    //}

    [HttpGet]
    public async Task<ActionResult<Response>> GetGoals()
    {
        var re = new Response(200, "These are all the current goals!", await _context.Goals.ToListAsync(), null, null);
        return Ok(re);
    }

    //[HttpGet("id")]
    //[ProducesResponseType(typeof(Goals), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetId(int id)
    //{
    //    var goal = await _context.Goals.FindAsync(id);
    //    return goal == null ? NotFound() : Ok(goal);
    //}


    [HttpGet("id")]
    [ProducesResponseType(typeof(Goals), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetId(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null)
        {
            return NotFound(new Response(404, "No goal with this id number was found :( Use the createGoal endpoint to add it as a new goal!", null, null, null));
        }
        else
        {
            return Ok(new Response(200, "Goal with this id was found :) Feel free to add new goals as you progress in them!",null, await _context.Goals.FindAsync(id), null));

        }
    }


    //[Route("/createGoal")]
    //[HttpPost]
    //public async Task<IActionResult> CreateGoal(CombinedViews cv)
    //{
    //    Goals g = new Goals();
    //    methods m = new methods();
    //    Users u = new Users();
    //    g = cv.goal;
    //    m = cv.method;
    //    u = cv.user;
    //    await _context.methods.AddAsync(m);
    //    await _context.SaveChangesAsync();
    //    await _context.Goals.AddAsync(g);
    //    await _context.SaveChangesAsync();
    //    await _context.Users.AddAsync(u);
    //    await _context.SaveChangesAsync();
    //    return CreatedAtAction(nameof(GetId), new {id= g.goals_id}, g);
    //}



    [Route("/createGoal")]
    [HttpPost]
    public async Task<IActionResult> CreateGoal(CombinedViews cv)
    {
        Goals g = new Goals();
        methods m = new methods();
        Users u = new Users();
        g = cv.goal;
        m = cv.method;
        u = cv.user;

        var goal = await _context.Goals.FindAsync(g.goals_id);
        var method = await _context.methods.FindAsync(m.method_id);
        if (goal != null)
        {
            return Conflict(new Response(409, "A goal with this id exists!! Please try a different id for this new goal", null, await _context.Goals.FindAsync(g.goals_id), null));

        }else if (method != null)
        {
            return Conflict(new Response(409, "A method with this id exists!! Please try a different id for this new goal", null, null, await _context.methods.FindAsync(m.method_id)));

        }
        else{
            await _context.methods.AddAsync(m);
            await _context.SaveChangesAsync();
            await _context.Goals.AddAsync(g);
            await _context.SaveChangesAsync();
            await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            return Ok(new Response(200, "Goal has been added! Good luck and best wishes on your journey.", null, await _context.Goals.FindAsync(g.goals_id), await _context.methods.FindAsync(m.method_id)));
        }

     }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Goals g)
    {
        if (id != g.goals_id || await _context.Goals.FindAsync(id) == null)
        {
            return BadRequest(new Response(400, "The id is not found or matches with system present :(", null, null, null));
        }

        var existingGoals = _context.Goals.Where(s => s.goals_id == g.goals_id).FirstOrDefault<Goals>();
        existingGoals.goal_desc = g.goal_desc;
        existingGoals.goal_title = g.goal_title;
        existingGoals.completed = g.completed;
        existingGoals.deadline = g.deadline;
        _context.SaveChanges();
        //_context.Entry(g).State = EntityState.Modified;
        //_context.Entry(g).State = EntityState.Detached;
        //_context.Set<Goals>().Update(g);
        //_context.SaveChanges();
        //await _context.SaveChangesAsync();
        return Accepted(new Response(204, "The goal item has been updated!", null, await _context.Goals.FindAsync(g.goals_id), null));
    }
}

