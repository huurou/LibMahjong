using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Tanyao(int Id) : Yaku(Id)
{
    public Tanyao(int id)
        : base(id) { }

    public override string Name => "断么九";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList, GameRules rules)
    {
        return hand.Concat(fuuroList.TileLists).SelectMany(x => x).Distinct().All(x => x.IsChuuchan) &&
            (!fuuroList.HasOpen || rules.Kuitan);
    }
}