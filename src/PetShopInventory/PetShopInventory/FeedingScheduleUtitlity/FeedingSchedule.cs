using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.FeedingScheduleUtitlity
{
    public class FeedingSchedule
    {
        public int Id { get; set; }
        public DateTime FeedingTime { get; set; }
        public string SpecialInstructions { get; set; }
        public int CageId { get; set; }
        public PetCage Cage { get; set; }
    }
}
