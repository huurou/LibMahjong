﻿using System.Collections;
using System.Collections.Immutable;

namespace LibMahjong.Tiles;

public class TileList : IEnumerable<Tile>, IEquatable<TileList>, IComparable<TileList>
{
    public int Count => tiles_.Count;
    public Tile this[Index index] => tiles_[index];
    public TileList this[Range range]
    {
        get
        {
            var (start, length) = range.GetOffsetAndLength(Count);
            return new(tiles_.Skip(start).Take(length));
        }
    }

    /// <summary>
    /// 対子かどうか
    /// </summary>
    public bool IsToitsu => Count == 2 && this[0] == this[1];
    /// <summary>
    /// 順子かどうか
    /// </summary>
    public bool IsShuntsu => Count == 3 && this[0].Id == this[1].Id - 1 && this[1].Id == this[2].Id - 1 &&
        (this.All(x => x.IsMan) || this.All(x => x.IsPin) || this.All(x => x.IsSou));
    /// <summary>
    /// 刻子かどうか
    /// </summary>
    public bool IsKoutsu => Count == 3 && this[1..].All(x => this[0] == x);
    /// <summary>
    /// 槓子かどうか
    /// </summary>
    public bool IsKantsu => Count == 4 && this[1..].All(x => this[0] == x);

    private readonly ImmutableList<Tile> tiles_ = [];
    private readonly ImmutableArray<int> counts_ = [];

    public TileList(IEnumerable<Tile> tiles)
    {
        if (tiles.Any(x => tiles.Count(y => y == x) > 4)) { throw new ArgumentException("同じ牌は4枚までです。", nameof(tiles)); }
        tiles_ = [.. tiles];
        counts_ = [.. Tile.All.Select(x => tiles.Count(y => y == x))];
    }

    public TileList(string man = "", string pin = "", string sou = "", string honor = "") : this(
        [
            .. man.Select(x => new Tile(int.Parse(x.ToString()) - 1)),
            .. pin.Select(x => new Tile(int.Parse(x.ToString()) + 8)),
            .. sou.Select(x => new Tile(int.Parse(x.ToString()) + 17)),
            .. honor.Select(x => new Tile(int.Parse(x.ToString()) + 26)),
        ]
    )
    {
    }

    public int CountOf(Tile tile)
    {
        return counts_[tile.Id];
    }

    public TileList Add(Tile tile)
    {
        return new(tiles_.Add(tile));
    }

    public TileList Remove(Tile tile, int count = 1)
    {
        var tiles = tiles_;
        for (var i = 0; i < count; i++)
        {
            tiles = tiles.Remove(tile);
        }
        return new(tiles);
    }

    public TileList GetIsolations()
    {
        return new(Tile.All.Where(
            x => x.IsHonor && CountOf(x) == 0 ||
                !x.IsHonor && x.Number == 1 && counts_[x.Id] == 0 && counts_[x.Id + 1] == 0 ||
                !x.IsHonor && x.Number is >= 2 and <= 8 && counts_[x.Id - 1] == 0 && CountOf(x) == 0 && counts_[x.Id + 1] == 0 ||
                !x.IsHonor && x.Number == 9 && counts_[x.Id - 1] == 0 && CountOf(x) == 0
        ));
    }

    public bool IsAgari()
    {
        return Agari.IsAgari(this);
    }

    public override string ToString()
    {
        return string.Join("", this);
    }

    public IEnumerator<Tile> GetEnumerator()
    {
        return tiles_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Equals(TileList? other)
    {
        return other is not null &&
            Count == other.Count &&
            (ReferenceEquals(this, other) || this.OrderBy(x => x).SequenceEqual(other.OrderBy(x => x)));
    }

    public override bool Equals(object? obj)
    {
        return obj is TileList other && Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int CompareTo(TileList? other)
    {
        if (other is null) { return 1; }
        var min = Math.Min(Count, other.Count);
        for (var i = 0; i < min; i++)
        {
            if (this[i] > other[i]) { return 1; }
            if (this[i] < other[i]) { return -1; }
        }
        return Count.CompareTo(other.Count);
    }

    public static bool operator ==(TileList? left, TileList? right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(TileList? left, TileList? right)
    {
        return !(left == right);
    }

    public static bool operator <(TileList? left, TileList? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(TileList? left, TileList? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(TileList? left, TileList? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    public static bool operator >=(TileList? left, TileList? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}
