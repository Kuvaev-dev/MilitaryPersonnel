using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class DocumentFlow
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public int CreatedById { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int StatusId { get; set; }

    public virtual Servicemen CreatedBy { get; set; } = null!;

    public virtual ICollection<DocumentAssignments> DocumentAssignments { get; set; } = new List<DocumentAssignments>();

    public virtual DocumentTypes DocumentType { get; set; } = null!;

    public virtual ICollection<Resolutions> Resolutions { get; set; } = new List<Resolutions>();

    public virtual DocumentStatuses Status { get; set; } = null!;
}
