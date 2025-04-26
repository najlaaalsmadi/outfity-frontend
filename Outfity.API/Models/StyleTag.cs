using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class StyleTag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ClosetItemTag> ClosetItemTags { get; set; } = new List<ClosetItemTag>();
}
