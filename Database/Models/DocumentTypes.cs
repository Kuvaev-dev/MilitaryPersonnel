using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class DocumentTypes
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<DocumentFlow> DocumentFlow { get; set; } = new List<DocumentFlow>();
}
