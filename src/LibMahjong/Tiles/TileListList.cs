using System.Collections;
using System.Collections.Immutable;

namespace LibMahjong.Tiles;

public class TileListList(IEnumerable<TileList> tileLists) : IEnumerable<TileList>, IEquatable<TileListList>
{
    public int Count => tileLists_.Count;

    public TileList this[Index index] => tileLists_[index];

    private readonly ImmutableList<TileList> tileLists_ = [.. tileLists];

    public static TileListList FromOneLine(IEnumerable<string> oneLines)
    {
        return new(oneLines.Select(TileList.FromOneLine));
    }

    public override string ToString()
    {
        return string.Join("", this.Select(x => $"[{x}]"));
    }

    public IEnumerator<TileList> GetEnumerator()
    {
        return tileLists_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Equals(TileListList other)
    {
        return this.OrderBy(x => x).SequenceEqual(other.OrderBy(x => x));
    }

    public override bool Equals(object obj)
    {
        return obj is TileListList other && Equals(other);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        foreach (var tileList in tileLists_)
        {
            hashCode.Add(tileList);
        }
        return hashCode.ToHashCode();
    }
}
