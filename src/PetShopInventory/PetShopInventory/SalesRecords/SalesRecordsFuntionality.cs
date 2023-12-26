using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.SalesRecords
{
    public class SalesRecordsFuntionality
    {
        private readonly ApplicationDbContext _context;

        public SalesRecordsFuntionality(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public void AddSalesRecord()
        {

        }
    }
}
