using MjLib.Fuuros;
using LibMahjong.Tiles;
using MjLib.TileKinds;
using static MjLib.TileKinds.Tile;

namespace LibMahjong.Yakus.Impls;

public record RoundWind(int Id) : Yaku(Id)
{
    public RoundWind(int id)
        : base(id) { }

    public override string Name => "場風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList_, WinSituation situation_)
    {
        return hand.Concat(fuuroList_.TileLists)
                   .Where(x => (x.IsKoutsu || x.IsKantsu) && x[0] == WindToTileKind(situation_.Round))
                   .Any();
    }

    private static Tile WindToTileKind(Wind wind)
    {
        return wind switch
        {
            Wind.East => Ton,
            Wind.South => Nan,
            Wind.West => Sha,
            Wind.North => Pei,
            _ => throw new NotSupportedException()
        };
    }
}