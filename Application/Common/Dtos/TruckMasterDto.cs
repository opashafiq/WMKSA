using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class TruckMasterDto
    {
        public long Id { get; set; }

        public string? TruckNo { get; set; }

        public long? DriverMasterId { get; set; }
        public string DriverMasterDriverCode { get; set; }
        public string DriverMasterDriverName { get; set; }

        public int? TransporterMasterId { get; set; }
        public string TransporterMasterTransCode { get; set; }
        public string TransporterMasterTransName { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        
    }
}
