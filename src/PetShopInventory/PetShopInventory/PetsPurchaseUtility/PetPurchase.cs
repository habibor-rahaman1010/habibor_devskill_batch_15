﻿using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.PetsPurchaseUtility
{
    public class PetPurchase
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string SellerContact { get; set; }
        public string Email { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<Pet> PurchasedPets { get; set; }
    }
}
