using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class Outfit
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsFavorite { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<OutfitItem> OutfitItems { get; set; } = new List<OutfitItem>();

    public virtual User? User { get; set; }
}
