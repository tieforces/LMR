
using System.ComponentModel;
namespace LegendaryMarvelRandomizer.Core.Models
{
    public enum Team
    {
        None,
        Avengers,
        [Description("X-Men")]
        XMen,
        [Description("S.H.I.E.L.D.")]
        SHIELD,
        [Description("Spider Friends")]
        SpiderFriends,
        [Description("Marvel Knights")]
        MarvelKnights,
        [Description("X-Force")]
        XForce,
        [Description("Fantastic Four")]
        FantasticFour
    }
}
