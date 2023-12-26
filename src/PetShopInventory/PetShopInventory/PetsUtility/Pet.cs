using PetShopInventory.PetsPurchaseUtility;
using PetShopInventory.SalesRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.PetsUtility
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int PetPrice {  get; set; }
        public string Type { get; set; }
        public int CageId {  get; set; }
        public PetCage Cage { get; set; }
        public int? PetPurchaseId { get; set; }
        public PetPurchase PetPurchase { get; set; }
        public int? PetSaleId { get; set; }
        public PetSalesRecord PetSale { get; set; }
    }
}
