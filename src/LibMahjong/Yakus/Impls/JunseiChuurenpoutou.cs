using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record JunseiChuurenpoutou(int Id) : Yaku(Id)
{
    public override string Name => "純正九蓮宝燈";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, Tile winTile)
    {
        var mans = hand.Where(x => x.IsAllMan);
        var pins = hand.Where(x => x.IsAllPin);
        var sous = hand.Where(x => x.IsAllSou);
        var suits = new[] { mans, pins, sous }.Where(x => x.Count() != 0);
        if (hand.All(x => x.IsAllMan) && winTile.IsMan ||
            hand.All(x => x.IsAllPin) && winTile.IsPin ||
            hand.All(x => x.IsAllSou) && winTile.IsSou)
        {
            return false;
        }
        var nums = hand.SelectMany(x => x, (_, x) => x.Number).ToList();
        // numsは 1112345678999+アガリ牌 になっているはず
        foreach (var n in new[] { 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 })
        {
            if (!nums.Remove(n)) { return false; }
        }
        return nums.Count == 1 && nums.ElementAt(0) == winTile.Number;
    }
}