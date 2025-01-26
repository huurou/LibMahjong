using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Daisangen(int Id) : Yaku(Id)
{
    public override string Name => "大三元";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        return tileLists.Count(x => (x.IsKoutsu || x.IsKantsu) && x.All(x => x.IsDragon)) == 3;
    }
}