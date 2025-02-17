﻿using MjLib.Fuuros;
using LibMahjong.Tiles;
using MjLib.TileKinds;

namespace LibMahjong.Yakus.Impls;

public record SuuankouTanki(int Id) : Yaku(Id)
{
    public SuuankouTanki(int id)
        : base(id) { }

    public override string Name => "四暗刻単騎";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, TileList winGroup, Tile winTile, FuuroList fuuroList, WinSituation situation)
    {
        var jantou = hand.Where(x => x.IsToitsu).First();
        var anko = situation.Tsumo
            ? hand.Where(x => x.IsKoutsu)
            : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankan = fuuroList.Where(x => x.IsAnkan).Select(x => x.Tiles);
        return jantou[0] == winTile && anko.Count() + ankan.Count() == 4;
    }
}