﻿using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Sanshokudoukou(int Id) : Yaku(Id)
{
    public Sanshokudoukou(int id)
        : base(id) { }

    public override string Name => "三色同刻";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        var koutsus = hand.Concat(fuuroList.TileLists).Where(x => x.IsKoutsu || x.IsKantsu).Select(x => x.Take(3).ToList());
        if (koutsus.Count() < 3) return false;
        var mans = koutsus.Where(x => x[0].IsMan);
        var pins = koutsus.Where(x => x[0].IsPin);
        var sous = koutsus.Where(x => x[0].IsSou);
        foreach (var man in mans)
        {
            foreach (var pin in pins)
            {
                foreach (var sou in sous)
                {
                    var manNum = man.Select(x => x.Number);
                    var pinNum = pin.Select(x => x.Number);
                    var souNum = sou.Select(x => x.Number);
                    if (manNum.SequenceEqual(pinNum) &&
                        pinNum.SequenceEqual(souNum) &&
                        souNum.SequenceEqual(manNum))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}