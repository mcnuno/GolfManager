using System;
using System.Collections.Generic;

namespace GolfManager.Model;

public partial class Club
{
    public Guid Idclub { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Hole> Holes { get; set; } = new List<Hole>();
}
