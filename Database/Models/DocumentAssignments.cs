using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class DocumentAssignments
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int AssigneeId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? CompletedDate { get; set; }

    public virtual Servicemen Servicemen { get; set; } = null!;

    public virtual DocumentFlow Document { get; set; } = null!;
}
