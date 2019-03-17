using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projekt1.Models;
using Projekt1.Data;
using Microsoft.EntityFrameworkCore;
using Projekt1.Data.Entities;

namespace Projekt1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiQuestionController : Controller
    {
        
        private readonly IBazaRepository repository;
        public ApiQuestionController(IBazaRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try{
                return Ok(repository.GetAllQuestion());
            }
            catch(Exception ex){
                return BadRequest($"Failed to get questions: {ex}");
            }
            
        }
        
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try{
                 var que= repository.GetQuestionById(id);
                if(que!=null) return Ok(que);
                else return NotFound();
            }
            catch(Exception ex){
                return BadRequest($"Failed to load question({id}): {ex}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Question model)
        {
            try
            {
                repository.AddEntity(model);
                if(repository.SaveAll())
                {
                    return Created($"/api/ApiQuestion/{model.Id}",model);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);   
            }
            return BadRequest($"Failed to save new question");
        }
    }
}