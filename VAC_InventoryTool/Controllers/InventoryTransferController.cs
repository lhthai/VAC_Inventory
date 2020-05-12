using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAPbobsCOM;

namespace VAC_InventoryTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryTransferController : ControllerBase
    {
        // POST: api/inventorytransfer
        [HttpPost]
        public void Post([FromBody] string fromWarehouse, string toWarehouse, string itemCode, double quantity)
        {
            StockTransfer doc = new StockTransfer();
            doc.DocDate = DateTime.Now;
            doc.FromWarehouse = fromWarehouse;
            doc.ToWarehouse = toWarehouse;

            doc.Lines.SetCurrentLine(0);
            doc.Lines.ItemCode = itemCode;
            doc.Lines.FromWarehouseCode = fromWarehouse;
            doc.Lines.WarehouseCode = toWarehouse;
            doc.Lines.Quantity = quantity;
        }

    }
}