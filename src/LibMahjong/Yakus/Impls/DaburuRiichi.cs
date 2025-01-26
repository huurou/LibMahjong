namespace LibMahjong.Yakus.Impls;

public record DaburuRiichi(int Id) : Yaku(Id)
{
    public override string Name => "ダブル立直";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.DaburuRiichi;
    }
}