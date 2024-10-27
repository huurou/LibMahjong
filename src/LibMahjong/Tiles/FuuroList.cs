using System.Collections;
using System.Collections.Immutable;

namespace LibMahjong.Tiles;

public class FuuroList(IEnumerable<Fuuro> fuuros) : IEnumerable<Fuuro>
{
    public bool HasOpen => this.Any(x => x.IsOpen);
    public IEnumerable<TileList> TileLists => this.Select(x => x.Tiles);

    private readonly ImmutableList<Fuuro> fuuros_ = [.. fuuros];

    public IEnumerator<Fuuro> GetEnumerator()
    {
        return fuuros_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(",", this);
    }
}
