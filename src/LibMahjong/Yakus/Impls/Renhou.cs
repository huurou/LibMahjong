﻿namespace LibMahjong.Yakus.Impls;

public record Renhou(int Id) : Yaku(Id)
{
    public Renhou(int id)
        : base(id) { }

    public override string Name => "人和";
    public override int HanOpen => 0;
    public override int HanClosed => 5;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, GameRules rules)
    {
        return situation.Renhou && !rules.RenhouAsYakuman;
    }
}