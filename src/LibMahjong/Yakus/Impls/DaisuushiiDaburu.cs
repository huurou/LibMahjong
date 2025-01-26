namespace LibMahjong.Yakus.Impls;

public record DaisuushiiDaburu(int Id) : Yaku(Id)
{
    public override string Name => "大四喜";
    public override int HanOpen => 26;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
}