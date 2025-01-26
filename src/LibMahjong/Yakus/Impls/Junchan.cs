using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Junchan(int Id) : Yaku(Id)
{
    public override string Name => "純全帯么九";
    public override int HanOpen => 2;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        var shuntsus = tileLists.Count(x => x.IsShuntsu);
        var routous = tileLists.Count(x => x.Any(x => x.IsRoutou));
        return shuntsus != 0 && routous == 5;
    }
}