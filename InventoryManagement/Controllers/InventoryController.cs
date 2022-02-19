using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        IInventoryService inventoryService;
        public InventoryController(IInventoryService service)
        {
            inventoryService = service;
        }

        // get all inventory
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInventory()
        {
            try
            {
                var inventory = inventoryService.GetInventoryList();
                if (inventory == null) return NotFound();
                return Ok(inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // get inventory detail by id
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetInventoryById(int id)
        {
            try
            {
                var inventory = inventoryService.GetInventoryDetailsById(id);
                if (inventory == null) return NotFound();
                return Ok(inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // post inventory
        // RequestBody= inventoryModel
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveInventory(Inventory inventoryModel)
        {
            try
            {
                var model = inventoryService.SaveInventory(inventoryModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // update inventory
        // RequestBody= inventoryModel
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateInventory(Inventory InventoryModel)
        {
            try
            {
                var model = inventoryService.UpdateInventory(InventoryModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // delete inventory
        // <param name="id"></param>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteInventory(int id)
        {
            try
            {
                var model = inventoryService.DeleteInventory(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
