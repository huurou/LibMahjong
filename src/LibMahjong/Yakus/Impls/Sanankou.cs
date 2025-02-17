﻿using MjLib.Fuuros;
using LibMahjong.Tiles;
using MjLib.TileKinds;

namespace LibMahjong.Yakus.Impls;

public record Sanankou(int Id) : Yaku(Id)
{
    public Sanankou(int id)
        : base(id) { }

    public override string Name => "三暗刻";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, TileList winGroup, FuuroList fuuroList, WinSituation situation)
    {
        var anko = situation.Tsumo
            ? hand.Where(x => x.IsKoutsu)
            : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankan = fuuroList.Where(x => x.IsAnkan).Select(x => x.Tiles);
        return anko.Count() + ankan.Count() == 3;
    }
}