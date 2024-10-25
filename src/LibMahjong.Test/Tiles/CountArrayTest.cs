using LibMahjong.Tiles;

namespace LibMahjong.Test.Tiles;

public class CountArrayTest
{
    [Fact]
    public void コンストラクタ_引数なくても成功()
    {
        // Act
        var ex = Record.Exception(() => _ = new CountArray());

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void コンストラクタ_tiles_同種の牌が5枚以上あるなら失敗()
    {
        // Arrange
        IEnumerable<Tile> tiles = [Tile.Man1, Tile.Man1, Tile.Man1, Tile.Man1, Tile.Man1];

        // Act
        var ex = Record.Exception(() => _ = new CountArray(tiles));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void コンストラクタ_counts_要素数が34でないなら失敗()
    {
        // Arrange
        var counts1 = Enumerable.Repeat(0, 33);
        var counts2 = Enumerable.Repeat(0, 35);

        // Act
        var ex1 = Record.Exception(() => _ = new CountArray(counts1));
        var ex2 = Record.Exception(() => _ = new CountArray(counts2));

        // Assert
        Assert.IsType<ArgumentException>(ex1);
        Assert.IsType<ArgumentException>(ex2);
    }

    [Fact]
    public void コンストラクタ_counts_要素数が0から4でないなら失敗()
    {
        // Arrange
        var counts1 = Enumerable.Repeat(0, 34).ToList();
        counts1[0] = -1;
        var counts2 = Enumerable.Repeat(0, 34).ToList();
        counts2[0] = 5;

        // Act
        var ex1 = Record.Exception(() => _ = new CountArray(counts1));
        var ex2 = Record.Exception(() => _ = new CountArray(counts2));

        // Assert
        Assert.IsType<ArgumentException>(ex1);
        Assert.IsType<ArgumentException>(ex2);
    }

    [Fact]
    public void GetIsolations()
    {
        // Arrange
        var counts = new TileList(man: "25", pin: "15678", sou: "1369", honor: "124").ToCountArray();

        // Act
        var isolations = counts.GetIsolations();

        // Assert
        Assert.Equal(new TileList(man: "789", pin: "3", honor: "3567"), isolations);
    }

    [Fact]
    public void ToTileList()
    {
        // Arrange
        var countArray = new CountArray([1, 2, 3, 4, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 4, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 2, 1, 3, 1, 4, 1, 1]);

        // Act
        var actual = countArray.ToTileList();

        // Assert
        Assert.Equal(new TileList(man: "12233344446789", pin: "123455666777788889", sou: "123456778889999", honor: "1123334555567"), actual);
    }

    [Fact]
    public void ToStringTest()
    {
        // Arrange
        var countArray = new CountArray([1, 2, 3, 4, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 4, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 2, 1, 3, 1, 4, 1, 1]);

        // Act
        var actual = countArray.ToString();

        // Assert

        Assert.Equal("m[123401111] p[111123441] s[111111234] z[2131411]", actual);
    }

    [Fact]
    public void ExceptionTest()
    {
        // Act
        var ex = Record.Exception(() => _ = new CountArray([1, 2, 3, 4, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 4, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 2, 1, 3, 1, 4, 1, 1, 0]));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }
}

// Arrange

// Act

// Assert
