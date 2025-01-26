namespace LibMahjong.Yakus.Impls;

public record Rinshan(int Id) : Yaku(Id)
{
    public Rinshan(int id)
        : base(id) { }

    public override string Name => "嶺上開花";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.Rinshan;
    }
}