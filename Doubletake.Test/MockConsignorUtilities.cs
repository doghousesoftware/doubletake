using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleTakeInventory.ConsignorClasses;

namespace Doubletake.Test
{
    public class ConsignorUtilitiesTesting : ConsignorUtilities
    {
        public override int AddNewConsignor(Consignor newcon)
        {
            return 5;
        }

        public override bool Consignor_Update(Consignor c)
        {
            return true;
        }
    }    
}
