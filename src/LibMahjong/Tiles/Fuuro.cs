namespace LibMahjong.Tiles;

/// <summary>
/// 副露 槓子は4枚
/// </summary>
public record Fuuro
{
    public FuuroType Type { get; init; }
    public TileList Tiles { get; init; }

    /// <summary>
    /// チーかどうか
    /// </summary>
    public bool IsChi => Type == FuuroType.Chi;
    /// <summary>
    /// ポンかどうか
    /// </summary>
    public bool IsPon => Type == FuuroType.Pon;
    /// <summary>
    /// 槓かどうか
    /// </summary>
    public bool IsKan => Type is FuuroType.Ankan or FuuroType.Minkan;
    /// <summary>
    /// 暗槓かどうか
    /// </summary>
    public bool IsAnkan => Type is FuuroType.Ankan;
    /// <summary>
    /// 明槓かどうか
    /// </summary>
    public bool IsMinkan => Type is FuuroType.Minkan;
    /// <summary>
    /// 抜きかどうか
    /// </summary>
    public bool IsNuki => Type is FuuroType.Nuki;
    /// <summary>
    /// 面前が崩れる副露かどうか
    /// </summary>
    public bool IsOpen => Type is FuuroType.Chi or FuuroType.Pon or FuuroType.Minkan;

    public Fuuro(FuuroType type, TileList tiles)
    {
        switch (type)
        {
            case FuuroType.Chi:
                if (!tiles.IsShuntsu) { throw new ArgumentException($"チーは順子のみ有効です。tiles:{tiles}", nameof(tiles)); }
                break;

            case FuuroType.Pon:
                if (!tiles.IsKoutsu) { throw new ArgumentException($"ポンは刻子のみ有効です。tiles:{tiles}", nameof(tiles)); }
                break;

            case FuuroType.Ankan:
                if (!tiles.IsKantsu) { throw new ArgumentException($"暗槓は槓子のみ有効です。tiles:{tiles}", nameof(tiles)); }
                break;

            case FuuroType.Minkan:
                if (!tiles.IsKantsu) { throw new ArgumentException($"明槓は槓子のみ有効です。tiles:{tiles}", nameof(tiles)); }
                break;

            case FuuroType.Nuki:
                break;

            default:
                throw new NotImplementedException();
        }
        Type = type;
        Tiles = tiles;
    }

    public override string ToString()
    {
        return $"{Type.ToStr()} {Tiles}";
    }
}
