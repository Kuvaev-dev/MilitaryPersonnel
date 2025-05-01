using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class MobilizationLists
{
    public int Id { get; set; }

    public string ListName { get; set; } = null!;

    public DateOnly? CreationDate { get; set; }

    public virtual ICollection<MobilizationListEntries> MobilizationListEntries { get; set; } = new List<MobilizationListEntries>();
}
