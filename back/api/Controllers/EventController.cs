using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class EventController : ControllerBase
{
    [HttpGet]
    public IActionResult All(bool includeAttendant,bool includeHeroes){
        //TODO
        return Ok();
    }

    [HttpPost]
    public IActionResult Add([FromBody] EventModel model){
        //TODO
        return Ok();
    }


    [HttpGet]
    public IActionResult Get([FromQuery] int id,bool includeAttendant,bool includeHeroes)
    {
        //TODO
        return Ok();
    }

}