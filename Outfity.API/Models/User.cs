using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Gender { get; set; }

    public string? HijabStyle { get; set; }

    public string? PreferredColors { get; set; }

    public string? PreferredStyles { get; set; }

    public string? BodyType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AiHistory> AiHistories { get; set; } = new List<AiHistory>();

    public virtual ICollection<ClosetItem> ClosetItems { get; set; } = new List<ClosetItem>();

    public virtual ICollection<Outfit> Outfits { get; set; } = new List<Outfit>();
}
