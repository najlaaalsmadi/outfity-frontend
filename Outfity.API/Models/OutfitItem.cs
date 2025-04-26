using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class OutfitItem
{
    public int Id { get; set; }

    public int? OutfitId { get; set; }

    public int? ClosetItemId { get; set; }

    public virtual ClosetItem? ClosetItem { get; set; }

    public virtual Outfit? Outfit { get; set; }
}
