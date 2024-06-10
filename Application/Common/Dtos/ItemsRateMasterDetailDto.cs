using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class ItemsRateMasterDetailDto
    {
        public long Id { get; set; }

        public int ItemsRateMasterId { get; set; }
        public string ItemsRateMasterRateCode { get; set; }

        public int ItemServiceId { get; set; }
        public string ItemServiceItemsService { get; set; }

        public int FreeDays { get; set; }

        public decimal Charges { get; set; }

        public int VatInc { get; set; }

        public decimal VatP { get; set; }

        public decimal VatAmo { get; set; }

        public decimal Trate { get; set; }

        public long RecItemMasterId { get; set; }
        public string RecItemMasterItemCode { get; set; }
        public string RecItemMasterItemDesc { get; set; }

        public long UnitMasterId { get; set; }
        public string UnitMasterMainUnit { get; set; }
        public string UnitMasterUnitCode { get; set; }

    }
}
