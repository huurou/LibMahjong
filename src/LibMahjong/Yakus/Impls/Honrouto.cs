using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Honrouto(int Id) : Yaku(Id)
{
    public override string Name => "混老頭";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        return tileLists.All(x => x.All(y => y.IsYaochuu));
    }
}