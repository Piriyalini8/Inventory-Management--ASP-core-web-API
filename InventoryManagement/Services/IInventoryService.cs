using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        List<Inventory> GetInventoryList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        // <param name="empId"></param>
        /// <returns></returns>
        Inventory GetInventoryDetailsById(int empId);

        /// <summary>
        ///  add edit employee
        /// </summary>
        // <param name="employeeModel"></param>
        /// <returns></returns>
        ResponseModel SaveInventory(Inventory InventoryModel);

        //edit
        ResponseModel UpdateInventory(Inventory InventoryModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        ResponseModel DeleteInventory(int inventoryId);
    }
}
