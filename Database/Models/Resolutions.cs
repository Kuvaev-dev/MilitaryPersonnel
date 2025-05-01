using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Resolutions
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int AuthorId { get; set; }

    public string ResolutionText { get; set; } = null!;

    public DateTime? ResolutionDate { get; set; }

    public virtual Servicemen Author { get; set; } = null!;

    public virtual DocumentFlow Document { get; set; } = null!;
}
