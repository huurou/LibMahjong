using LibMahjong.Tiles;

namespace LibMahjong.Test;

public class AgariTest
{
    [Fact]
    public void IsAgari_字牌が4枚以上ならFalse()
    {
        // Arrange
        var tiles = new TileList(honor: "1111");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsAgari_国士無双のアガリ形ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "19", pin: "19", sou: "19", honor: "12345677");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_国士無双のアガリ形でないのに1枚だけの字牌があるならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "1234444778899", pin: "123", honor: "1");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsAgari_七対子のアガリ形ならTrue()
    {
        // Arrange
        var tiles = new TileList(man: "11223344556677");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_対子が含まれていないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "123444778899", pin: "123444");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsAgari_萬子に対子があるパターン()
    {
        // Arrange
        var tiles = new TileList(man: "12345678911", pin: "123");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_筒子に対子があるパターン()
    {
        // Arrange
        var tiles = new TileList(man: "123456789", pin: "12311");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_索子に対子があるパターン()
    {
        // Arrange
        var tiles = new TileList(man: "123456789", pin: "123", sou: "11");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_字牌に対子があるパターン()
    {
        // Arrange
        var tiles = new TileList(man: "123456789", pin: "123", honor: "11");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsAgari_対子を含むスートが正しい面子で構成されていないならFalse()
    {
        // Arrange
        var tiles = new TileList(man: "12345677911", pin: "123");

        // Act
        var actual = tiles.IsAgari();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsAgari_面子が正しく構成されているならTrue()
    {
        // Arrange
        // 123
        var tiles1 = new TileList(man: "123456789", pin: "123", honor: "11");
        // 111
        var tiles2 = new TileList(man: "111456789", pin: "123", honor: "11");
        // 112233
        var tiles3 = new TileList(man: "112233456", pin: "123", honor: "11");
        // 111123
        var tiles4 = new TileList(man: "111123456", pin: "123", honor: "11");

        // Act
        var actual1 = tiles1.IsAgari();
        var actual2 = tiles2.IsAgari();
        var actual3 = tiles3.IsAgari();
        var actual4 = tiles4.IsAgari();

        // Assert
        Assert.True(actual1);
        Assert.True(actual2);
        Assert.True(actual3);
        Assert.True(actual4);
    }

    [Fact]
    public void IsAgari_面子が正しく構成されていないならFalse()
    {
        // Arrange
        // 1_3
        var tiles1 = new TileList(man: "134567899", pin: "11123");
        // 12_
        var tiles2 = new TileList(man: "124567899", pin: "123", sou: "11");
        // 112_33
        var tiles3 = new TileList(man: "112334569", pin: "123", honor: "11");
        // 11223_
        var tiles4 = new TileList(man: "112234569", pin: "123", honor: "11");

        // Act
        var actual1 = tiles1.IsAgari();
        var actual2 = tiles2.IsAgari();
        var actual3 = tiles3.IsAgari();
        var actual4 = tiles4.IsAgari();

        // Assert
        Assert.False(actual1);
        Assert.False(actual2);
        Assert.False(actual3);
        Assert.False(actual4);
    }

    [Fact]
    public void IsAgari_True()
    {
        Assert.True(new TileList(man: "33", pin: "123", sou: "123456789").IsAgari());
        Assert.True(new TileList(pin: "11123", sou: "123456789").IsAgari());
        Assert.True(new TileList(sou: "123456789", honor: "11777").IsAgari());
        Assert.True(new TileList(sou: "12345556778899").IsAgari());
        Assert.True(new TileList(sou: "11123456788999").IsAgari());
        Assert.True(new TileList(man: "345", pin: "789", sou: "233334", honor: "55").IsAgari());
        Assert.True(new TileList(sou: "12345667788889").IsAgari());
        Assert.True(new TileList(man: "12344456777888").IsAgari());
        Assert.True(new TileList(pin: "45566777789999").IsAgari());
        Assert.True(new TileList(pin: "45566677888999").IsAgari());
        Assert.True(new TileList(man: "112233", pin: "123", sou: "11", honor: "111").IsAgari());
        Assert.True(new TileList(man: "11122233").IsAgari());
    }

    [Fact]
    public void IsAgari_False()
    {
        Assert.False(new TileList(pin: "12345", sou: "123456789").IsAgari());
        Assert.False(new TileList(pin: "11145", sou: "111222444").IsAgari());
        Assert.False(new TileList(sou: "11122233356888").IsAgari());
        Assert.False(new TileList(pin: "12356667778999").IsAgari());
        // 数牌1枚余り
        Assert.False(new TileList(man: "123456789", pin: "1", honor: "111").IsAgari());
        // 対子2つ
        Assert.False(new TileList(man: "123456", pin: "11", sou: "11", honor: "111").IsAgari());
        // 数牌2つ余り&&字牌の対子あり
        Assert.False(new TileList(man: "123456", pin: "111", sou: "12", honor: "11").IsAgari());
        Assert.False(new TileList(man: "123456", pin: "111", sou: "12", honor: "1111").IsAgari());
        // 順子を取った残りが不適切
        Assert.False(new TileList(man: "112334", pin: "123", sou: "123", honor: "111").IsAgari());
    }
}

// Arrange

// Act

// Assert
