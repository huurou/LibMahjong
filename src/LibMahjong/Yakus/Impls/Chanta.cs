using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Chanta(int Id) : Yaku(Id)
{
    public override string Name => "混全帯幺九";
    public override int HanOpen => 1;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);
        var shuntsu = tileLists.Count(x => x.IsShuntsu);
        var routou = tileLists.Count(x => x.Any(y => y.IsRoutou));
        var honor = tileLists.Count(x => x.IsAllHonor);
        return shuntsu != 0 && routou + honor == 5 && routou != 0 && honor != 0;
    }
}