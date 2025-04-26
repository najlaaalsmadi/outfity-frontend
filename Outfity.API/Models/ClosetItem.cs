using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class ClosetItem
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Color { get; set; }

    public string? Season { get; set; }

    public string? Occasion { get; set; }

    public string? Material { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ClosetItemTag> ClosetItemTags { get; set; } = new List<ClosetItemTag>();

    public virtual ICollection<OutfitItem> OutfitItems { get; set; } = new List<OutfitItem>();

    public virtual User? User { get; set; }
}
