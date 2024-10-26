using LibMahjong.Tiles;

namespace LibMahjong.Test.Tiles;

public class TileListTest
{
    [Fact]
    public void コンストラクタ()
    {
        // Act
        var tiles = new TileList(man: "123456789", pin: "123456789", sou: "123456789", honor: "1234567");

        // Assert
        Assert.Equal(
            new TileList(
                [
                    Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4, Tile.Man5, Tile.Man6, Tile.Man7, Tile.Man8, Tile.Man9,
                    Tile.Pin1, Tile.Pin2, Tile.Pin3, Tile.Pin4, Tile.Pin5, Tile.Pin6, Tile.Pin7, Tile.Pin8, Tile.Pin9,
                    Tile.Sou1, Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou5, Tile.Sou6, Tile.Sou7, Tile.Sou8, Tile.Sou9,
                    Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei, Tile.Haku, Tile.Hatsu, Tile.Chun
                ]
            ), tiles)
        ;
    }

    [Fact]
    public void コンストラクタ_同じ牌が5枚以上なら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new TileList(man: "11111"));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void IsToitsu_同じ牌が2枚ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "11");

        // Act
        var actual = tiles.IsToitsu;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsToitsu_異なる牌ならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "12");

        // Act
        var actual = tiles.IsToitsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsToitsu_3枚ならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "111");

        // Act
        var actual = tiles.IsToitsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsShuntsu_同スートで3枚の連続した数牌ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "123");

        // Act
        var actual = tiles.IsShuntsu;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsShuntsu_隣り合っていないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "124");

        // Act
        var actual = tiles.IsShuntsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsShuntsu_3枚でないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "1234");

        // Act
        var actual = tiles.IsShuntsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsShuntsu_Idが連続でも同スートでないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "89", pin: "1");

        // Act
        var actual = tiles.IsShuntsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsKoutsu_同じ牌が3枚ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "111");

        // Act
        var actual = tiles.IsKoutsu;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsKoutsu_異なる牌ならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "112");

        // Act
        var actual = tiles.IsKoutsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsKoutsu_3枚でないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "1111");

        // Act
        var actual = tiles.IsKoutsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsKantsu_同じ牌が4枚ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "1111");

        // Act
        var actual = tiles.IsKantsu;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsKantsu_異なる牌ならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "1112");

        // Act
        var actual = tiles.IsKantsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsKantsu_4枚でないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "111");

        // Act
        var actual = tiles.IsKantsu;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CountOf()
    {
        // Arrange
        var tiles = new TileList(man: "1111222334");

        // Act
        var actual1 = tiles.CountOf(Tile.Man1);
        var actual2 = tiles.CountOf(Tile.Man2);
        var actual3 = tiles.CountOf(Tile.Man3);
        var actual4 = tiles.CountOf(Tile.Man4);
        var actual5 = tiles.CountOf(Tile.Man5);

        // Assert
        Assert.Equal(4, actual1);
        Assert.Equal(3, actual2);
        Assert.Equal(2, actual3);
        Assert.Equal(1, actual4);
        Assert.Equal(0, actual5);
    }

    [Fact]
    public void Add()
    {
        // Arrange
        var tiles = new TileList(man: "123");

        // Act
        var actual = tiles.Add(Tile.Man4);

        // Assert
        Assert.Equal(new TileList(man: "123"), tiles); // 元のtilesは変更されない
        Assert.Equal(new TileList(man: "1234"), actual);
    }

    [Fact]
    public void GetIsolations()
    {
        // Arrange
        var tiles = new TileList(man: "25", pin: "15678", sou: "1369", honor: "124");

        // Act
        var actual = tiles.GetIsolations();

        // Assert
        Assert.Equal(new TileList(man: "789", pin: "3", honor: "3567"), actual);
    }

    [Fact]
    public void ToString_()
    {
        // Arrange
        var tiles = new TileList(Tile.All);

        // Act
        var actual = tiles.ToString();

        // Assert
        Assert.Equal("一二三四五六七八九(1)(2)(3)(4)(5)(6)(7)(8)(9)123456789東南西北白發中", actual);
    }

    [Fact]
    public void Equals_並び順が異なっていても要素が同じならTrue()
    {
        // Arrange
        var tiles = new TileList([Tile.Man1, Tile.Man2, Tile.Man3]);
        var other = new TileList([Tile.Man3, Tile.Man1, Tile.Man2]);

        // Act
        var actual = tiles.Equals(other);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Equals_参照が同じならTrue()
    {
        // Arrange
        var tiles = new TileList([Tile.Man1, Tile.Man2, Tile.Man3]);

        // Act
        var actual = tiles.Equals(tiles);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Equals_nullならFalse()
    {
        // Arrange
        var tiles = new TileList([Tile.Man1, Tile.Man2, Tile.Man3]);
        TileList? other = null;

        // Act
        var actual = tiles.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Equals_objectバージョン()
    {
        // Arrange
        object tiles = new TileList([Tile.Man1, Tile.Man2, Tile.Man3]);

        // Act
        var actual = new TileList(man: "123").Equals(tiles);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Equals_objectバージョン_null()
    {
        // Arrange
        object? tiles = null;

        // Act
        var actual = new TileList(man: "123").Equals(tiles);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CompareTo_LessThan_要素が異なる()
    {
        // Arrange
        var tiles = new TileList(man: "123");
        var other = new TileList(man: "124");

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.True(actual < 0);
    }

    [Fact]
    public void CompareTo_LessThan_数が異なる()
    {
        // Arrange
        var tiles = new TileList(man: "123");
        var other = new TileList(man: "1233");

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.True(actual < 0);
    }

    [Fact]
    public void CompareTo_MoreThan_要素が異なる()
    {
        // Arrange
        var tiles = new TileList(man: "124");
        var other = new TileList(man: "123");

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.True(actual > 0);
    }

    [Fact]
    public void CompareTo_MoreThan_数が異なる()
    {
        // Arrange
        var tiles = new TileList(man: "1233");
        var other = new TileList(man: "123");

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.True(actual > 0);
    }

    [Fact]
    public void CompareTo_Equal()
    {
        // Arrange
        var tiles = new TileList(man: "123");
        var other = new TileList(man: "123");

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void CompareTo_null()
    {
        // Arrange
        var tiles = new TileList(man: "123");
        TileList? other = null;

        // Act
        var actual = tiles.CompareTo(other);

        // Assert
        Assert.True(actual > 0);
    }
}

// Arrange

// Act

// Assert
