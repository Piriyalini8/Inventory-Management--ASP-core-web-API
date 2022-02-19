using InventoryManagement.Models;
using InventoryManagement.Services;

namespace InventoryManagement.Services.ServiceImpl
{
    public class InventoryServiceImpl : IInventoryService
    {
        private InventoryContext context;
        public InventoryServiceImpl(InventoryContext _context)
        {
            this.context = _context;
        }

        // Get all inventory
        public List<Inventory> GetInventoryList()
        {
            List<Inventory> invList;
            try
            {
                invList = context.Set<Inventory>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return invList;
        }

        // get inventory detail by id
        public Inventory GetInventoryDetailsById(int invId)
        {
            Inventory inv;
            try
            {
                inv = context.Find<Inventory>(invId);
            }
            catch (Exception)
            {
                throw;
            }
            return inv;
        }

        // post inventory
        public ResponseModel SaveInventory(Inventory InventoryModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Inventory temp = GetInventoryDetailsById(InventoryModel.InventoryId);
                if (temp != null)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Inventory Already Exist";
                }
                else
                {
                    context.Add<Inventory>(InventoryModel);
                    context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Inventory Inserted Successfully";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        // update inventory
        public ResponseModel UpdateInventory(Inventory InventoryModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Inventory temp = GetInventoryDetailsById(InventoryModel.InventoryId);
                if (temp != null)
                {
                    temp.InventoryName = InventoryModel.InventoryName;
                    temp.Description = InventoryModel.Description;
                    temp.UnitPrice = InventoryModel.UnitPrice;
                    temp.AvailableUnits = InventoryModel.AvailableUnits;
                    temp.ReOrderLevel = InventoryModel.ReOrderLevel;
                    context.Update<Inventory>(temp);
                    context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Inventory Updated Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Inventory not Exist";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        // delete inventory
        public ResponseModel DeleteInventory(int invId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Inventory temp = GetInventoryDetailsById(invId);
                if (temp != null)
                {
                    context.Remove<Inventory>(temp);
                    context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Inventory Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Inventory Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }    
    }
}
