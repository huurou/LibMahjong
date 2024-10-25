using System.Collections;
using System.Collections.Immutable;

namespace LibMahjong.Tiles;

public class CountArray : IEnumerable<int>
{
    public int this[Index index] => array_[index];
    public int this[Tile tile] => array_[tile.Id];

    private readonly ImmutableArray<int> array_ = ImmutableArray.Create([.. Enumerable.Repeat(0, 34)]);

    public CountArray(IEnumerable<Tile> tiles) : this(Enumerable.Range(0, 34).Select(x => tiles.Count(y => y.Id == x)))
    {
    }

    public CountArray(IEnumerable<int>? counts = default)
    {
        if (counts is null) { return; }
        if (counts.Count() != 34) { throw new ArgumentException($"引数の長さが牌種類数と一致しません。 counts.Count():{counts.Count()}", nameof(counts)); }
        if (counts.Any(x => x is < 0 or > 4)) { throw new ArgumentException($"牌は0~4枚です。", nameof(counts)); }
        array_ = [.. counts];
    }

    public TileList GetIsolations()
    {
        var isolatations = new TileList();
        foreach (var tile in Tile.All)
        {
            if (tile.IsHonor && this[tile] == 0 ||
                !tile.IsHonor && tile.Number == 1 && this[tile] == 0 && this[tile.Id + 1] == 0 ||
                !tile.IsHonor && tile.Number is >= 2 and <= 8 && this[tile.Id - 1] == 0 && this[tile] == 0 && this[tile.Id + 1] == 0 ||
                !tile.IsHonor && tile.Number == 9 && this[tile.Id - 1] == 0 && this[tile] == 0)
            {
                isolatations = isolatations.Add(tile);
            }
        }
        return isolatations;
    }

    public TileList ToTileList()
    {
        return new(this);
    }

    public override string ToString()
    {
        var s = string.Join("", array_);
        return $"m[{s.Substring(Tile.Man1.Id, 9)}] p[{s.Substring(Tile.Pin1.Id, 9)}] s[{s.Substring(Tile.Sou1.Id, 9)}] z[{s.Substring(Tile.Ton.Id, 7)}]";
    }

    public IEnumerator<int> GetEnumerator()
    {
        return array_.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
