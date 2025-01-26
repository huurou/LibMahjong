using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Toitoihou(int Id) : Yaku(Id)
{
    public Toitoihou(int id)
        : base(id) { }

    public override string Name => "対々和";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        return hand.Concat(fuuroList.TileLists).Count(x => x.IsKoutsu || x.IsKantsu) == 4;
    }
}