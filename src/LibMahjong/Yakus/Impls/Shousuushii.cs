﻿using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Shousuushii(int Id) : Yaku(Id)
{
    public Shousuushii(int id)
        : base(id) { }

    public override string Name => "小四喜";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, FuuroList fuuroList_)
    {
        var tileKinds = hand.Concat(fuuroList_.TileLists);
        var koutsus = tileKinds.Where(x => x.IsKoutsu || x.IsKantsu);
        var toitsus = tileKinds.Where(x => x.IsToitsu);
        return koutsus.Count(x => x[0].IsWind) == 3 && toitsus.Count(x => x[0].IsWind) == 1;
    }
}