using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Daisharin(int Id) : Yaku(Id)
{
    public override string Name => "大車輪"; public override int HanOpen => 0; public override int HanClosed => 13; public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, GameRules rules)
    {
        return rules.Daisharin && hand == TileListList.FromOneLine(["22m", "33m", "44m", "55m", "66m", "77m", "88m"]);
    }
}