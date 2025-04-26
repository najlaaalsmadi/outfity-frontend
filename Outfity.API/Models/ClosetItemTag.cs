using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class ClosetItemTag
{
    public int Id { get; set; }

    public int? ClosetItemId { get; set; }

    public int? StyleTagId { get; set; }

    public virtual ClosetItem? ClosetItem { get; set; }

    public virtual StyleTag? StyleTag { get; set; }
}
