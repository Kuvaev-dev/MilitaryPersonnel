using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class MobilizationListEntries
{
    public int Id { get; set; }

    public int? MobilizationListId { get; set; }

    public int? ServicemanId { get; set; }

    public virtual MobilizationLists? MobilizationList { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
