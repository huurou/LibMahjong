using LibMahjong.Tiles;
using MjLib.TileCountArrays;
using MjLib.TileKinds;

namespace LibMahjong.Yakus.Impls;

public record Kokushimusou13(int Id) : Yaku(Id)
{
    public override string Name => "国士無双十三面待ち";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;

    public static bool Valid(CountArray countArray, Tile? winTile)
    {
        return winTile is not null &&
            countArray[winTile] == 2 &&
            Tile.AllKind.Where(x => x.IsYaochuu).Aggregate(1, (x, y) => x * countArray[y]) == 2;
    }
}