namespace LibMahjong.Yakus.Impls;

public record Ippatsu(int Id) : Yaku(Id)
{
    public override string Name => "一発";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.Ippatsu;
    }
}