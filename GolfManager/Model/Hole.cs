using System;
using System.Collections.Generic;

namespace GolfManager.Model;

public partial class Hole
{
    public Guid Idhole { get; set; }

    public Guid Idclub { get; set; }

    public int Par { get; set; }

    public int Distance { get; set; }

    public int Hazards { get; set; }

    public virtual Club? IdclubNavigation { get; set; } = null!;
}
