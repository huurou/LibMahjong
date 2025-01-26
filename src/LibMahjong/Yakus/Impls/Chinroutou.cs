using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Chinroutou(int Id) : Yaku(Id)
{
    public override string Name => "清老頭";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        return tileLists.All(x => x.All(y => y.IsRoutou));
    }
}