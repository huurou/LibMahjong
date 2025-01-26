using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Haku(int Id) : Yaku(Id)
{
    public override string Name => "白";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        return tileLists.Any(x => (x.IsKoutsu || x.IsKantsu) && x.All(y => y == Tile.Haku));
    }
}