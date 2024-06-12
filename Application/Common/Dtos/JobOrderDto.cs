using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class JobOrderDto
{
    public long Id { get; set; }

    public string? JobFileNo { get; set; }

    public DateTime? JobFileDate { get; set; }

    public long? CustomerMasterId { get; set; }
    public string CustomerMasterCustCode { get; set; }
    public string CustomerMasterCustName { get; set; }
    public int? Service { get; set; }

    public string? JobStatus { get; set; }

    public string? JobRefNo { get; set; }

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public static implicit operator JobOrderDto(JobOrder v)
    {
        throw new NotImplementedException();
    }
}
