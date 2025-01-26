using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Kokushimusou(int Id) : Yaku(Id)
{
    public override string Name => "国士無双";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    internal static bool Valid(TileListList hand)
    {
        var tiles = hand.SelectMany(x => x).ToList();
        foreach (var yaochuu in Tile.Yaochuus)
        {
            if (!tiles.Remove(yaochuu)) { return false; }
        }
        return tiles.Count == 1 && tiles[0].IsYaochuu;
    }
}