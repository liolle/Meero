using meero.bll;
using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Mvc;

namespace meero.api.controllers;

public class LocationController(ILocationService l) : Controller
{
    [HttpGet]
    public IActionResult All(){
        return Ok(l.GetAll());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok(l.GetById(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] LocationModel model){
        
        if (!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        try
        {
            
            LocationEntity location = new(){
                Address=model.Address,
                City=model.City,
                Country=model.Country,
                LocationImage=model.LocationImage,
                GoogleFrame=model.GoogleFrame,
                IsVirtual=model.IsVirtual,
            };

            l.Insert(location);
            
        }
        catch (DatabaseException e)
        {
            return Ok(new{message=e.Message});
        }

        return Ok(new{message=""});
    }
}