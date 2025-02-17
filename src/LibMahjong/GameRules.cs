﻿namespace LibMahjong;

/// <summary>
/// 点数に関わるルール
/// </summary>
public record GameRules
{
    /// <summary>
    /// 喰いタンあり/なし
    /// </summary>
    public bool Kuitan { get; init; } = true;

    /// <summary>
    /// ダブル役満あり/なし
    /// </summary>
    public bool DaburuYakuman { get; init; } = true;

    /// <summary>
    /// 数え役満
    /// </summary>
    public Kazoe KazoeLimit { get; init; } = Kazoe.Limited;

    /// <summary>
    /// 切り上げ満貫あり/なし
    /// </summary>
    public bool Kiriage { get; init; } = false;

    /// <summary>
    /// ピンヅモあり/なし
    /// </summary>
    public bool Pinzumo { get; init; } = true;

    /// <summary>
    /// 人和役満あり/なし
    /// </summary>
    public bool RenhouAsYakuman { get; init; } = false;

    /// <summary>
    /// 大車輪あり/なし
    /// </summary>
    public bool Daisharin { get; init; } = false;
}
