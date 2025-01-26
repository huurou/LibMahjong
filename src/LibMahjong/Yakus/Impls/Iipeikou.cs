using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Iipeikou(int Id) : Yaku(Id)
{
    public override string Name => "一盃口";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        if (fuuroList.HasOpen) { return false; };
        return hand.Where(x => x.IsShuntsu).GroupBy(x => x).Any(x => x.Count() >= 2);
    }
}