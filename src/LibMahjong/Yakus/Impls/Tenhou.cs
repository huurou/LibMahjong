namespace LibMahjong.Yakus.Impls;

public record Tenhou(int Id) : Yaku(Id)
{
    public Tenhou(int id)
        : base(id) { }

    public override string Name => "天和";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(WinSituation situation)
    {
        return situation.Tenhou;
    }
}