namespace LibMahjong;

/// <summary>
/// 牌 <para/>
/// 全34種類の牌を表現するクラス
/// 0～33までのIdを持つ
/// 同種の牌の区別はライブラリ使用側が行えばいい
/// </summary>
public record Tile : IComparable<Tile>
{
    /// <summary>
    /// 一萬
    /// </summary>
    public static Tile Man1 { get; } = new(0);
    /// <summary>
    /// 二萬
    /// </summary>
    public static Tile Man2 { get; } = new(1);
    /// <summary>
    /// 三萬
    /// </summary>
    public static Tile Man3 { get; } = new(2);
    /// <summary>
    /// 四萬
    /// </summary>
    public static Tile Man4 { get; } = new(3);
    /// <summary>
    /// 五萬
    /// </summary>
    public static Tile Man5 { get; } = new(4);
    /// <summary>
    /// 六萬
    /// </summary>
    public static Tile Man6 { get; } = new(5);
    /// <summary>
    /// 七萬
    /// </summary>
    public static Tile Man7 { get; } = new(6);
    /// <summary>
    /// 八萬
    /// </summary>
    public static Tile Man8 { get; } = new(7);
    /// <summary>
    /// 九萬
    /// </summary>
    public static Tile Man9 { get; } = new(8);
    /// <summary>
    /// 一筒
    /// </summary>
    public static Tile Pin1 { get; } = new(9);
    /// <summary>
    /// 二筒
    /// </summary>
    public static Tile Pin2 { get; } = new(10);
    /// <summary>
    /// 三筒
    /// </summary>
    public static Tile Pin3 { get; } = new(11);
    /// <summary>
    /// 四筒
    /// </summary>
    public static Tile Pin4 { get; } = new(12);
    /// <summary>
    /// 五筒
    /// </summary>
    public static Tile Pin5 { get; } = new(13);
    /// <summary>
    /// 六筒
    /// </summary>
    public static Tile Pin6 { get; } = new(14);
    /// <summary>
    /// 七筒
    /// </summary>
    public static Tile Pin7 { get; } = new(15);
    /// <summary>
    /// 八筒
    /// </summary>
    public static Tile Pin8 { get; } = new(16);
    /// <summary>
    /// 九筒
    /// </summary>
    public static Tile Pin9 { get; } = new(17);
    /// <summary>
    /// 一索
    /// </summary>
    public static Tile Sou1 { get; } = new(18);
    /// <summary>
    /// 二索
    /// </summary>
    public static Tile Sou2 { get; } = new(19);
    /// <summary>
    /// 三索
    /// </summary>
    public static Tile Sou3 { get; } = new(20);
    /// <summary>
    /// 四索
    /// </summary>
    public static Tile Sou4 { get; } = new(21);
    /// <summary>
    /// 五索
    /// </summary>
    public static Tile Sou5 { get; } = new(22);
    /// <summary>
    /// 六索
    /// </summary>
    public static Tile Sou6 { get; } = new(23);
    /// <summary>
    /// 七索
    /// </summary>
    public static Tile Sou7 { get; } = new(24);
    /// <summary>
    /// 八索
    /// </summary>
    public static Tile Sou8 { get; } = new(25);
    /// <summary>
    /// 九索
    /// </summary>
    public static Tile Sou9 { get; } = new(26);
    /// <summary>
    /// 東
    /// </summary>
    public static Tile Ton { get; } = new(27);
    /// <summary>
    /// 南
    /// </summary>
    public static Tile Nan { get; } = new(28);
    /// <summary>
    /// 西
    /// </summary>
    public static Tile Sha { get; } = new(29);
    /// <summary>
    /// 北
    /// </summary>
    public static Tile Pei { get; } = new(30);
    /// <summary>
    /// 白
    /// </summary>
    public static Tile Haku { get; } = new(31);
    /// <summary>
    /// 發
    /// </summary>
    public static Tile Hatsu { get; } = new(32);
    /// <summary>
    /// 中
    /// </summary>
    public static Tile Chun { get; } = new(33);

    /// <summary>
    /// 牌Id
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// 牌に書かれている番号 萬子・筒子・索子は1～9 字牌は東南西北白發中の順に1～7
    /// </summary>
    public int Number =>
        IsMan ? Id + 1 :
        IsPin ? Id - 8 :
        IsSou ? Id - 17 :
        IsHonor ? Id - 26 :
        throw new InvalidOperationException();
    /// <summary>
    /// 萬子かどうか
    /// </summary>
    public bool IsMan => Id is >= 0 and <= 8;
    /// <summary>
    /// 筒子かどうか
    /// </summary>
    public bool IsPin => Id is >= 9 and <= 17;
    /// <summary>
    /// 索子かどうか
    /// </summary>
    public bool IsSou => Id is >= 18 and <= 26;
    /// <summary>
    /// 風牌かどうか
    /// </summary>
    public bool IsWind => Id is >= 27 and <= 30;
    /// <summary>
    /// 三元牌かどうか
    /// </summary>
    public bool IsDragon => Id >= 31;
    /// <summary>
    /// 字牌かどうか
    /// </summary>
    public bool IsHonor => IsWind || IsDragon;
    /// <summary>
    /// 中張牌かどうか
    /// </summary>
    public bool IsChuuchan => !IsYaochuu;
    /// <summary>
    /// 么九牌かどうか
    /// </summary>
    public bool IsYaochuu => IsRoutou || IsHonor;
    /// <summary>
    /// 老頭牌かどうか
    /// </summary>
    public bool IsRoutou => Id is 0 or 8 or 9 or 17 or 18 or 26;

    public Tile(int id)
    {
        Id = id is >= 0 and <= 33
            ? id
            : throw new ArgumentException($"牌種別IDは{0}～{33}です。{nameof(id)}:{id}", nameof(id));
    }

    public int CompareTo(Tile? other)
    {
        return other is not null ? Id.CompareTo(other.Id) : throw new ArgumentNullException(nameof(other));
    }

    public static bool operator <(Tile? left, Tile? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(Tile? left, Tile? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(Tile? left, Tile? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    public static bool operator >=(Tile? left, Tile? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}
