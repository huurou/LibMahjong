namespace LibMahjong.Yakus.Impls;

public record Chiihou(int Id) : Yaku(Id)
{
    public override string Name => "地和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(WinSituation situation)
    {
        return situation.Chiihou;
    }
}