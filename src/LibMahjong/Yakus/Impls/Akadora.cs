﻿namespace LibMahjong.Yakus.Impls;

public record Akadora(int Id) : Yaku(Id)
{
    public override string Name => "赤ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}