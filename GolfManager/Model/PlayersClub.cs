using System;
using System.Collections.Generic;

namespace GolfManager.Model;

public partial class PlayersClub
{
    public Guid Idplayer { get; set; }

    public Guid Idclub { get; set; }

    public DateTime SubscriptionDate { get; set; }

    public virtual Club IdclubNavigation { get; set; } = null!;

    public virtual Player IdplayerNavigation { get; set; } = null!;
}
