﻿using MjLib.Fuuros;
using LibMahjong.Tiles;
using MjLib.TileKinds;

namespace LibMahjong.Yakus.Impls;

public record Suuankou(int Id) : Yaku(Id)
{
    public Suuankou(int id)
        : base(id) { }

    public override string Name => "四暗刻";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, TileList winGroup, FuuroList fuuroList, WinSituation situation)
    {
        var anko = situation.Tsumo
            ? hand.Where(x => x.IsKoutsu)
            : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankan = fuuroList.Where(x => x.IsAnkan).Select(x => x.Tiles);
        return anko.Count() + ankan.Count() == 4;
    }
}