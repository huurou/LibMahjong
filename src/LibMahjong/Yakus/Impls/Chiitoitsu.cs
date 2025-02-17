﻿using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Chiitoitsu(int Id) : Yaku(Id)
{
    public override string Name => "七対子";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand)
    {
        return hand.Count == 7 && hand.All(x => x.IsToitsu);
    }
}