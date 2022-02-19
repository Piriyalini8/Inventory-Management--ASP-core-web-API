using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId
        {
            get;
            set;
        }
        public string? InventoryName
        {
            get;
            set;
        }
        public string? Description
        {
            get;
            set;
        }
        public decimal UnitPrice
        {
            get;
            set;
        }
        public int AvailableUnits
        {
            get;
            set;
        }
        public int ReOrderLevel
        {
            get;
            set;
        }
    }
}
