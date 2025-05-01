using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class DocumentStatuses
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<DocumentFlow> DocumentFlow { get; set; } = new List<DocumentFlow>();
}
