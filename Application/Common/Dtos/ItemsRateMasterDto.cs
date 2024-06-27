using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class ItemsRateMasterDto
    {
        public int ItemsRateMasterId { get; set; }

        public string RateCode { get; set; } = null!;

        public long CustomerMasterId { get; set; }

        public decimal EntryBy { get; set; }

        public DateTime EntryDate { get; set; }


    }
}
