using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Punishments
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? PunishmentDescription { get; set; }

    public DateOnly? PunishmentDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
