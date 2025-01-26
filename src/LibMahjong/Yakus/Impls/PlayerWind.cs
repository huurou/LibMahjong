using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record PlayerWind(int Id) : Yaku(Id)
{
    public PlayerWind(int id)
        : base(id) { }

    public override string Name => "自風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList_, WinSituation situation_)
    {
        return hand.Concat(fuuroList_.TileLists)
                   .Where(x => (x.IsKoutsu || x.IsKantsu) && x[0] == WindToTileKind(situation_.Player))
                   .Any();
    }

    private static Tile WindToTileKind(Wind wind)
    {
        return wind switch
        {
            Wind.East => Tile.Ton,
            Wind.South => Tile.Nan,
            Wind.West => Tile.Sha,
            Wind.North => Tile.Pei,
            _ => throw new NotSupportedException()
        };
    }
}