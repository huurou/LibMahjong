using MjLib.Fuuros;
using LibMahjong.Tiles;

namespace LibMahjong.Yakus.Impls;

public record Suukantsu(int Id) : Yaku(Id)
{
    public Suukantsu(int id)
        : base(id) { }

    public override string Name => "四槓子";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileListList hand, FuuroList fuuroList)
    {
        return hand.Concat(fuuroList.TileLists).Count(x => x.IsKantsu) == 4;
    }
}