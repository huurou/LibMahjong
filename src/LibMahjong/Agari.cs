using LibMahjong.Tiles;

namespace LibMahjong;

public static class Agari
{
    /// <summary>
    /// 指定の手牌がアガリ形かどうかを判定します。
    /// </summary>
    /// <param name="hand">判定対象の手牌 面前の手牌のみ指定</param>
    /// <returns>アガリ形かどうか</returns>
    public static bool IsAgari(TileList hand)
    {
        // 字牌が4枚以上ならアガリ形ではない
        if (Tile.Honors.Any(x => hand.CountOf(x) >= 4)) { return false; }
        // 国士無双のアガリ形かどうか判断する
        if (Tile.Yaochuus.Count(x => hand.CountOf(x) == 1) == 12 && Tile.Yaochuus.Count(x => hand.CountOf(x) == 2) == 1) { return true; }
        // 国士無双でないのに1枚だけの字牌があるならアガリ形ではない
        if (Tile.Honors.Any(x => hand.CountOf(x) == 1)) { return false; }
        // 七対子のアガリ形かどうか判断する
        if (Tile.All.Count(x => hand.CountOf(x) == 2) == 7) { return true; }
        // 通常のアガリ形について判断する
        return IsAgariForRegular(hand);
    }

    private static bool IsAgariForRegular(TileList hand)
    {
        // スートごとにhandを分割する
        var handMan = new TileList(hand.Where(x => x.IsMan));
        var handPin = new TileList(hand.Where(x => x.IsPin));
        var handSou = new TileList(hand.Where(x => x.IsSou));
        var handHonor = new TileList(hand.Where(x => x.IsHonor));
        // mod(3)が2ならそのスートに対子が含まれているはず
        var hasToitsuMan = handMan.Count % 3 == 2;
        var hasToitsuPin = handPin.Count % 3 == 2;
        var hasToitsuSou = handSou.Count % 3 == 2;
        var hasToitsuHonor = handHonor.Count % 3 == 2;
        // 対子はいずれかのスートに1組だけ存在するはず
        if (new[] { hasToitsuMan, hasToitsuPin, hasToitsuSou, hasToitsuHonor }.Count(x => x) != 1) { return false; }
        // 対子を持っているスートごとにそれぞれの構成要素を検証する
        if (hasToitsuMan)
        {
            return
                HasToitsuAndMentsu(handMan, false) &&
                HasMentsuOnly(handPin, false) &&
                HasMentsuOnly(handSou, false) &&
                HasMentsuOnly(handHonor, true);
        }
        else if (hasToitsuPin)
        {
            return
                HasToitsuAndMentsu(handPin, false) &&
                HasMentsuOnly(handMan, false) &&
                HasMentsuOnly(handSou, false) &&
                HasMentsuOnly(handHonor, true);
        }
        else if (hasToitsuSou)
        {
            return
                HasToitsuAndMentsu(handSou, false) &&
                HasMentsuOnly(handMan, false) &&
                HasMentsuOnly(handPin, false) &&
                HasMentsuOnly(handHonor, true);
        }
        else
        {
            return
                HasToitsuAndMentsu(handHonor, true) &&
                HasMentsuOnly(handMan, false) &&
                HasMentsuOnly(handPin, false) &&
                HasMentsuOnly(handSou, false);
        }
    }

    // 対子1つと面子のみで構成されているかどうか
    private static bool HasToitsuAndMentsu(TileList tiles, bool honor)
    {
        // 2個以上存在する牌は対子の可能性がある
        // 試しに取り除いてみて残りが面子のみで構成されているならOK
        foreach (var tile in Tile.All.Where(x => tiles.CountOf(x) >= 2))
        {
            if (HasMentsuOnly(tiles.Remove(tile, 2), honor)) { return true; }
        }
        return false;
    }

    // 面子のみで構成されているかどうか
    private static bool HasMentsuOnly(TileList tiles, bool honor)
    {
        if (honor)
        {
            return tiles.All(x => tiles.CountOf(x) == 3);
        }
        else
        {
            // 左の牌から順番に見ていく
            foreach (var tile in Tile.All.Where(x => tiles.CountOf(x) != 0))
            {
                // 見ている牌の次の種類の牌
                var tile1 = new Tile(tile.Id + 1);
                // 見ている牌の次の次の種類の牌
                var tile2 = new Tile(tile.Id + 2);
                // 左端の牌が1or4個のときは次と次の次の牌で順子を構成するはずなのでそれぞれ削除する
                if (tiles.CountOf(tile) is 1 or 4)
                {
                    if (tiles.CountOf(tile1) == 0) { return false; }
                    if (tiles.CountOf(tile2) == 0) { return false; }
                    tiles = tiles.Remove(tile1).Remove(tile2);
                }
                // 左端の牌が2個のときは次と次の次の牌で2つの順子を構成するはずなのでそれぞれ2個ずつ削除する
                else if (tiles.CountOf(tile) == 2)
                {
                    if (tiles.CountOf(tile1) < 2) { return false; }
                    if (tiles.CountOf(tile2) < 2) { return false; }
                    tiles = tiles.Remove(tile1, 2).Remove(tile2, 2);
                }
                // 左端の牌が3個のときはその牌で刻子を構成するはず
                // 左端の牌を全て削除する
                tiles = tiles.Remove(tile, tiles.CountOf(tile));
            }
            return true;
        }
    }
}
