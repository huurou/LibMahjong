using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Sankantsu(int Id) : Yaku(Id)
{
    public Sankantsu(int id)
        : base(id) { }

    public override string Name => "三槓子";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        return hand.Concat(fuuroList.TileLists).Count(x => x.IsKantsu) == 3;
    }
}