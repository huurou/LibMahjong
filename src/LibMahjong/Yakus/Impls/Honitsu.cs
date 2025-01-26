using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Honitsu(int Id) : Yaku(Id)
{
    public override string Name => "混一色";
    public override int HanOpen => 2;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var tileLists = new TileListList([.. hand, .. fuuroList.TileLists]);

        var man = tileLists.Count(x => x.IsAllMan);
        var pin = tileLists.Count(x => x.IsAllPin);
        var sou = tileLists.Count(x => x.IsAllSou);
        var honor = tileLists.Count(x => x.IsAllHonor);
        return new[] { man, pin, sou }.Count(x => x != 0) == 1 && honor != 0;
    }
}