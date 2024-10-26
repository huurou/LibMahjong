namespace LibMahjong.Tiles;

/// <summary>
/// 副露種別
/// </summary>
public enum FuuroType
{
    /// <summary>
    /// チー
    /// </summary>
    Chi,
    /// <summary>
    /// ポン
    /// </summary>
    Pon,
    /// <summary>
    /// 暗槓
    /// </summary>
    Ankan,
    /// <summary>
    /// 明槓 大明槓または小明槓
    /// </summary>
    Minkan,
    /// <summary>
    /// <summary>
    /// 抜き
    /// </summary>
    Nuki,
}

public static class FuuroTypeExtensions
{
    public static string ToStr(this FuuroType type)
    {
        return type switch
        {
            FuuroType.Chi => "チー",
            FuuroType.Pon => "ポン",
            FuuroType.Ankan => "暗槓",
            FuuroType.Minkan => "明槓",
            FuuroType.Nuki => "抜き",
            _ => throw new NotImplementedException(),
        };
    }
}