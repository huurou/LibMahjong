namespace LibMahjong.Yakus.Impls;

public record Chankan(int Id) : Yaku(Id)
{
    public override string Name => "槍槓";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.Chankan;
    }
}