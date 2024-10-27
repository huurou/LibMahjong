using LibMahjong.Tiles;

namespace LibMahjong.Test.Tiles;

public class FuuroListTest
{
    [Fact]
    public void HasOpen_True()
    {
        // Arrange
        var fuuros = new FuuroList([new(FuuroType.Ankan, new(man: "1111")), new(FuuroType.Chi, new(pin: "123"))]);

        // Act
        var actual = fuuros.HasOpen;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void HasOpen_False()
    {
        // Arrange
        var fuuros = new FuuroList([new(FuuroType.Ankan, new(man: "1111")), new(FuuroType.Ankan, new(pin: "1111"))]);

        // Act
        var actual = fuuros.HasOpen;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void TileLists()
    {
        // Arrange
        var fuuros = new FuuroList([new(FuuroType.Pon, new(man: "111")), new(FuuroType.Chi, new(pin: "123"))]);

        // Act
        var actual = fuuros.TileLists;

        // Assert
        Assert.Equal([new TileList(man: "111"), new TileList(pin: "123")], actual);
    }

    [Fact]
    public void ToString_()
    {
        // Arrange
        var fuuros = new FuuroList([new(FuuroType.Pon, new(man: "111")), new(FuuroType.Chi, new(pin: "123"))]);

        // Act
        var actual = fuuros.ToString();

        // Assert
        Assert.Equal("ポン 一一一,チー (1)(2)(3)", actual);

    }
}

// Arrange

// Act

// Assert
