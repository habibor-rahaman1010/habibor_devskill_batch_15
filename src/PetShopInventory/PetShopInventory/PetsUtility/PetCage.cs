using PetShopInventory.FeedingScheduleUtitlity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.PetsUtility
{
    public class PetCage
    {
        public int ID { get; set; }
        public string CageName { get; set; }
        public string CageType { get; set; }
        public List<Pet> PetsList { get; set; }
        public List<FeedingSchedule> PetCageFeedingSchedules { get; set; }
    }
}
