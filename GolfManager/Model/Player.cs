using System;
using System.Collections.Generic;

namespace GolfManager.Model;

public partial class Player
{
    public Guid Idplayer { get; set; }

    public string? Name { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Address { get; set; }
}
