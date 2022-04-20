using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IBookService _bookservice;
        public HomeController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookservice.GetAll());
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook()
        {
            Book book = new Book()
            {
                Title="ccc",
                Author="ccc",
                Pages=70
            };
            await _bookservice.CreateAsync(book);
            return StatusCode(200);
            
        }
        
    }
}
