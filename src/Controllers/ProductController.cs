using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ayudantia.src.Data;
using ayudantia.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ayudantia.src.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context){
            _context = context;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(){
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product  product){
            _ = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}