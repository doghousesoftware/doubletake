using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleTakeInventory.InventoryClasses;

namespace Doubletake.Test
{
    class MockInventoryUtilities : InventoryUtilities
    {
        public override bool SaveInventory(InventoryObject newInventory)
        {
            return true;
        }
    }
}

