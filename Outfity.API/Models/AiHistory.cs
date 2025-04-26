using System;
using System.Collections.Generic;

namespace Outfity.API.Models;

public partial class AiHistory
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TriggeredByItemId { get; set; }

    public int? SuggestedOutfitId { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
