namespace LibMahjong.Yakus.Impls;

public record Uradora(int Id) : Yaku(Id)
{
    public Uradora(int id)
        : base(id) { }

    public override string Name => "裏ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}