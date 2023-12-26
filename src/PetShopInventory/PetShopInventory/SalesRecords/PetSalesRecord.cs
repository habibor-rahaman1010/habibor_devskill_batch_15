using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.SalesRecords
{
    public class PetSalesRecord
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string BuyerContact { get; set; }
        public string TypeOfPet { get; set; }
        public DateTime SalesDate { get; set; }
        public List<Pet> SoldPets { get; set; }
    }
}
