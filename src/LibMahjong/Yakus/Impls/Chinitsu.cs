using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Chinitsu(int Id) : Yaku(Id)
{
    public override string Name => "清一色";
    public override int HanOpen => 5;
    public override int HanClosed => 6;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        return tileLists.All(x => x.IsAllMan) || tileLists.All(x => x.IsAllPin) || tileLists.All(x => x.IsAllSou);
    }
}