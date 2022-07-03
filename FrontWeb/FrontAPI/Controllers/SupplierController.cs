using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FrontDAL.Models;
using System.Threading.Tasks;
using FrontDAL;
using Newtonsoft.Json;

namespace FrontAPI.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        // GET: api/<SupplierController>
        [HttpGet]
        public List<Supplier> Get()
        {
            List<Supplier> suppliers = new SupplierManager().GetSuppliers();
            
            return suppliers;
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] Supplier supplier)
        {
            SupplierManager supplierManager = new SupplierManager();
            supplierManager.AddSupplier(supplier);
        }
    }
}
