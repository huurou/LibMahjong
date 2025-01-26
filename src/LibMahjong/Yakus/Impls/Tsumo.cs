using MjLib.Fuuros;

namespace LibMahjong.Yakus.Impls;

public record Tsumo(int Id) : Yaku(Id)
{
    public Tsumo(int id)
        : base(id) { }

    public override string Name => "門前清自摸和";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.Tsumo && !fuuroList.HasOpen;
    }
}