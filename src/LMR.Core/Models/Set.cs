using System.ComponentModel;

namespace LMR.Core.Models
{
    public enum Set
    {
        Core,
        [Description("Dark City")]
        DarkCity,
        [Description("Fantastic Four")]
        FantasticFour,
        [Description("Paint The Town Red")]
        PaintTheTownRed,
        Villains
    }
}
