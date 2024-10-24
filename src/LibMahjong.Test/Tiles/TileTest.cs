using LibMahjong.Tiles;

namespace LibMahjong.Test.Tiles;

public class TileTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(33)]
    public void コンストラクタ_0以上33以下で成功(int id)
    {
        // Act
        _ = new Tile(id);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(34)]
    public void コンストラクタ_0未満33超過で失敗(int id)
    {
        // Act
        var ex = Record.Exception(() => _ = new Tile(id));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void All()
    {
        // Act
        var actual = Tile.All;

        // Assert
        IEnumerable<Tile> expected = [
            Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4, Tile.Man5, Tile.Man6, Tile.Man7, Tile.Man8, Tile.Man9,
            Tile.Pin1, Tile.Pin2, Tile.Pin3, Tile.Pin4, Tile.Pin5, Tile.Pin6, Tile.Pin7, Tile.Pin8, Tile.Pin9,
            Tile.Sou1, Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou5, Tile.Sou6, Tile.Sou7, Tile.Sou8, Tile.Sou9,
            Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei, Tile.Haku, Tile.Hatsu, Tile.Chun,
        ];
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Number()
    {
        Assert.Equal(1, Tile.Man1.Number);
        Assert.Equal(2, Tile.Man2.Number);
        Assert.Equal(3, Tile.Man3.Number);
        Assert.Equal(4, Tile.Man4.Number);
        Assert.Equal(5, Tile.Man5.Number);
        Assert.Equal(6, Tile.Man6.Number);
        Assert.Equal(7, Tile.Man7.Number);
        Assert.Equal(8, Tile.Man8.Number);
        Assert.Equal(9, Tile.Man9.Number);
        Assert.Equal(1, Tile.Pin1.Number);
        Assert.Equal(2, Tile.Pin2.Number);
        Assert.Equal(3, Tile.Pin3.Number);
        Assert.Equal(4, Tile.Pin4.Number);
        Assert.Equal(5, Tile.Pin5.Number);
        Assert.Equal(6, Tile.Pin6.Number);
        Assert.Equal(7, Tile.Pin7.Number);
        Assert.Equal(8, Tile.Pin8.Number);
        Assert.Equal(9, Tile.Pin9.Number);
        Assert.Equal(1, Tile.Sou1.Number);
        Assert.Equal(2, Tile.Sou2.Number);
        Assert.Equal(3, Tile.Sou3.Number);
        Assert.Equal(4, Tile.Sou4.Number);
        Assert.Equal(5, Tile.Sou5.Number);
        Assert.Equal(6, Tile.Sou6.Number);
        Assert.Equal(7, Tile.Sou7.Number);
        Assert.Equal(8, Tile.Sou8.Number);
        Assert.Equal(9, Tile.Sou9.Number);
        Assert.Equal(1, Tile.Ton.Number);
        Assert.Equal(2, Tile.Nan.Number);
        Assert.Equal(3, Tile.Sha.Number);
        Assert.Equal(4, Tile.Pei.Number);
        Assert.Equal(5, Tile.Haku.Number);
        Assert.Equal(6, Tile.Hatsu.Number);
        Assert.Equal(7, Tile.Chun.Number);
    }

    [Fact]
    public void Number_Idが不正な時失敗()
    {
        // Arrange
        var tile = new Tile(0);
        var propInfo = typeof(Tile).GetProperty("Id");
        propInfo?.SetValue(tile, -1);

        // Act
        var ex = Record.Exception(() => _ = tile.Number);

        // Assert
        Assert.IsType<InvalidOperationException>(ex);
    }

    [Fact]
    public void IsMan_Success()
    {
        Assert.True(Tile.Man1.IsMan);
        Assert.True(Tile.Man2.IsMan);
        Assert.True(Tile.Man3.IsMan);
        Assert.True(Tile.Man4.IsMan);
        Assert.True(Tile.Man5.IsMan);
        Assert.True(Tile.Man6.IsMan);
        Assert.True(Tile.Man7.IsMan);
        Assert.True(Tile.Man8.IsMan);
        Assert.True(Tile.Man9.IsMan);
    }

    [Fact]
    public void IsMan_Failed()
    {
        Assert.False(Tile.Pin1.IsMan);
        Assert.False(Tile.Pin2.IsMan);
        Assert.False(Tile.Pin3.IsMan);
        Assert.False(Tile.Pin4.IsMan);
        Assert.False(Tile.Pin5.IsMan);
        Assert.False(Tile.Pin6.IsMan);
        Assert.False(Tile.Pin7.IsMan);
        Assert.False(Tile.Pin8.IsMan);
        Assert.False(Tile.Pin9.IsMan);
        Assert.False(Tile.Sou1.IsMan);
        Assert.False(Tile.Sou2.IsMan);
        Assert.False(Tile.Sou3.IsMan);
        Assert.False(Tile.Sou4.IsMan);
        Assert.False(Tile.Sou5.IsMan);
        Assert.False(Tile.Sou6.IsMan);
        Assert.False(Tile.Sou7.IsMan);
        Assert.False(Tile.Sou8.IsMan);
        Assert.False(Tile.Sou9.IsMan);
        Assert.False(Tile.Ton.IsMan);
        Assert.False(Tile.Nan.IsMan);
        Assert.False(Tile.Sha.IsMan);
        Assert.False(Tile.Pei.IsMan);
        Assert.False(Tile.Haku.IsMan);
        Assert.False(Tile.Hatsu.IsMan);
        Assert.False(Tile.Chun.IsMan);
    }

    [Fact]
    public void IsPin_True()
    {
        Assert.True(Tile.Pin1.IsPin);
        Assert.True(Tile.Pin2.IsPin);
        Assert.True(Tile.Pin3.IsPin);
        Assert.True(Tile.Pin4.IsPin);
        Assert.True(Tile.Pin5.IsPin);
        Assert.True(Tile.Pin6.IsPin);
        Assert.True(Tile.Pin7.IsPin);
        Assert.True(Tile.Pin8.IsPin);
        Assert.True(Tile.Pin9.IsPin);
    }

    [Fact]
    public void IsPin_False()
    {
        Assert.False(Tile.Man1.IsPin);
        Assert.False(Tile.Man2.IsPin);
        Assert.False(Tile.Man3.IsPin);
        Assert.False(Tile.Man4.IsPin);
        Assert.False(Tile.Man5.IsPin);
        Assert.False(Tile.Man6.IsPin);
        Assert.False(Tile.Man7.IsPin);
        Assert.False(Tile.Man8.IsPin);
        Assert.False(Tile.Man9.IsPin);
        Assert.False(Tile.Sou1.IsPin);
        Assert.False(Tile.Sou2.IsPin);
        Assert.False(Tile.Sou3.IsPin);
        Assert.False(Tile.Sou4.IsPin);
        Assert.False(Tile.Sou5.IsPin);
        Assert.False(Tile.Sou6.IsPin);
        Assert.False(Tile.Sou7.IsPin);
        Assert.False(Tile.Sou8.IsPin);
        Assert.False(Tile.Sou9.IsPin);
        Assert.False(Tile.Ton.IsPin);
        Assert.False(Tile.Nan.IsPin);
        Assert.False(Tile.Sha.IsPin);
        Assert.False(Tile.Pei.IsPin);
        Assert.False(Tile.Haku.IsPin);
        Assert.False(Tile.Hatsu.IsPin);
        Assert.False(Tile.Chun.IsPin);
    }

    [Fact]
    public void IsSou_Trie()
    {
        Assert.True(Tile.Sou1.IsSou);
        Assert.True(Tile.Sou2.IsSou);
        Assert.True(Tile.Sou3.IsSou);
        Assert.True(Tile.Sou4.IsSou);
        Assert.True(Tile.Sou5.IsSou);
        Assert.True(Tile.Sou6.IsSou);
        Assert.True(Tile.Sou7.IsSou);
        Assert.True(Tile.Sou8.IsSou);
        Assert.True(Tile.Sou9.IsSou);
    }

    [Fact]
    public void IsSou_False()
    {
        Assert.False(Tile.Man1.IsSou);
        Assert.False(Tile.Man2.IsSou);
        Assert.False(Tile.Man3.IsSou);
        Assert.False(Tile.Man4.IsSou);
        Assert.False(Tile.Man5.IsSou);
        Assert.False(Tile.Man6.IsSou);
        Assert.False(Tile.Man7.IsSou);
        Assert.False(Tile.Man8.IsSou);
        Assert.False(Tile.Man9.IsSou);
        Assert.False(Tile.Pin1.IsSou);
        Assert.False(Tile.Pin2.IsSou);
        Assert.False(Tile.Pin3.IsSou);
        Assert.False(Tile.Pin4.IsSou);
        Assert.False(Tile.Pin5.IsSou);
        Assert.False(Tile.Pin6.IsSou);
        Assert.False(Tile.Pin7.IsSou);
        Assert.False(Tile.Pin8.IsSou);
        Assert.False(Tile.Pin9.IsSou);
        Assert.False(Tile.Ton.IsSou);
        Assert.False(Tile.Nan.IsSou);
        Assert.False(Tile.Sha.IsSou);
        Assert.False(Tile.Pei.IsSou);
        Assert.False(Tile.Haku.IsSou);
        Assert.False(Tile.Hatsu.IsSou);
        Assert.False(Tile.Chun.IsSou);
    }

    [Fact]
    public void IsWind_True()
    {
        Assert.True(Tile.Ton.IsWind);
        Assert.True(Tile.Nan.IsWind);
        Assert.True(Tile.Sha.IsWind);
        Assert.True(Tile.Pei.IsWind);
    }

    [Fact]
    public void IsWind_False()
    {
        Assert.False(Tile.Man1.IsWind);
        Assert.False(Tile.Man2.IsWind);
        Assert.False(Tile.Man3.IsWind);
        Assert.False(Tile.Man4.IsWind);
        Assert.False(Tile.Man5.IsWind);
        Assert.False(Tile.Man6.IsWind);
        Assert.False(Tile.Man7.IsWind);
        Assert.False(Tile.Man8.IsWind);
        Assert.False(Tile.Man9.IsWind);
        Assert.False(Tile.Pin1.IsWind);
        Assert.False(Tile.Pin2.IsWind);
        Assert.False(Tile.Pin3.IsWind);
        Assert.False(Tile.Pin4.IsWind);
        Assert.False(Tile.Pin5.IsWind);
        Assert.False(Tile.Pin6.IsWind);
        Assert.False(Tile.Pin7.IsWind);
        Assert.False(Tile.Pin8.IsWind);
        Assert.False(Tile.Pin9.IsWind);
        Assert.False(Tile.Sou1.IsWind);
        Assert.False(Tile.Sou2.IsWind);
        Assert.False(Tile.Sou3.IsWind);
        Assert.False(Tile.Sou4.IsWind);
        Assert.False(Tile.Sou5.IsWind);
        Assert.False(Tile.Sou6.IsWind);
        Assert.False(Tile.Sou7.IsWind);
        Assert.False(Tile.Sou8.IsWind);
        Assert.False(Tile.Sou9.IsWind);
        Assert.False(Tile.Haku.IsWind);
        Assert.False(Tile.Hatsu.IsWind);
        Assert.False(Tile.Chun.IsWind);
    }

    [Fact]
    public void IsDragon_True()
    {
        Assert.True(Tile.Haku.IsDragon);
        Assert.True(Tile.Hatsu.IsDragon);
        Assert.True(Tile.Chun.IsDragon);
    }

    [Fact]
    public void IsDragon_False()
    {
        Assert.False(Tile.Man1.IsDragon);
        Assert.False(Tile.Man2.IsDragon);
        Assert.False(Tile.Man3.IsDragon);
        Assert.False(Tile.Man4.IsDragon);
        Assert.False(Tile.Man5.IsDragon);
        Assert.False(Tile.Man6.IsDragon);
        Assert.False(Tile.Man7.IsDragon);
        Assert.False(Tile.Man8.IsDragon);
        Assert.False(Tile.Man9.IsDragon);
        Assert.False(Tile.Pin1.IsDragon);
        Assert.False(Tile.Pin2.IsDragon);
        Assert.False(Tile.Pin3.IsDragon);
        Assert.False(Tile.Pin4.IsDragon);
        Assert.False(Tile.Pin5.IsDragon);
        Assert.False(Tile.Pin6.IsDragon);
        Assert.False(Tile.Pin7.IsDragon);
        Assert.False(Tile.Pin8.IsDragon);
        Assert.False(Tile.Pin9.IsDragon);
        Assert.False(Tile.Sou1.IsDragon);
        Assert.False(Tile.Sou2.IsDragon);
        Assert.False(Tile.Sou3.IsDragon);
        Assert.False(Tile.Sou4.IsDragon);
        Assert.False(Tile.Sou5.IsDragon);
        Assert.False(Tile.Sou6.IsDragon);
        Assert.False(Tile.Sou7.IsDragon);
        Assert.False(Tile.Sou8.IsDragon);
        Assert.False(Tile.Sou9.IsDragon);
        Assert.False(Tile.Ton.IsDragon);
        Assert.False(Tile.Nan.IsDragon);
        Assert.False(Tile.Sha.IsDragon);
        Assert.False(Tile.Pei.IsDragon);
    }

    [Fact]
    public void IsSuit_True()
    {
        Assert.True(Tile.Man1.IsSuit);
        Assert.True(Tile.Man2.IsSuit);
        Assert.True(Tile.Man3.IsSuit);
        Assert.True(Tile.Man4.IsSuit);
        Assert.True(Tile.Man5.IsSuit);
        Assert.True(Tile.Man6.IsSuit);
        Assert.True(Tile.Man7.IsSuit);
        Assert.True(Tile.Man8.IsSuit);
        Assert.True(Tile.Man9.IsSuit);
        Assert.True(Tile.Pin1.IsSuit);
        Assert.True(Tile.Pin2.IsSuit);
        Assert.True(Tile.Pin3.IsSuit);
        Assert.True(Tile.Pin4.IsSuit);
        Assert.True(Tile.Pin5.IsSuit);
        Assert.True(Tile.Pin6.IsSuit);
        Assert.True(Tile.Pin7.IsSuit);
        Assert.True(Tile.Pin8.IsSuit);
        Assert.True(Tile.Pin9.IsSuit);
        Assert.True(Tile.Sou1.IsSuit);
        Assert.True(Tile.Sou2.IsSuit);
        Assert.True(Tile.Sou3.IsSuit);
        Assert.True(Tile.Sou4.IsSuit);
        Assert.True(Tile.Sou5.IsSuit);
        Assert.True(Tile.Sou6.IsSuit);
        Assert.True(Tile.Sou7.IsSuit);
        Assert.True(Tile.Sou8.IsSuit);
        Assert.True(Tile.Sou9.IsSuit);
    }

    [Fact]
    public void IsSuit_False()
    {
        Assert.False(Tile.Ton.IsSuit);
        Assert.False(Tile.Nan.IsSuit);
        Assert.False(Tile.Sha.IsSuit);
        Assert.False(Tile.Pei.IsSuit);
        Assert.False(Tile.Haku.IsSuit);
        Assert.False(Tile.Hatsu.IsSuit);
        Assert.False(Tile.Chun.IsSuit);
    }

    [Fact]
    public void IsHonor_True()
    {
        Assert.True(Tile.Ton.IsHonor);
        Assert.True(Tile.Nan.IsHonor);
        Assert.True(Tile.Sha.IsHonor);
        Assert.True(Tile.Pei.IsHonor);
        Assert.True(Tile.Haku.IsHonor);
        Assert.True(Tile.Hatsu.IsHonor);
        Assert.True(Tile.Chun.IsHonor);
    }

    [Fact]
    public void IsHonor_False()
    {
        Assert.False(Tile.Man1.IsHonor);
        Assert.False(Tile.Man2.IsHonor);
        Assert.False(Tile.Man3.IsHonor);
        Assert.False(Tile.Man4.IsHonor);
        Assert.False(Tile.Man5.IsHonor);
        Assert.False(Tile.Man6.IsHonor);
        Assert.False(Tile.Man7.IsHonor);
        Assert.False(Tile.Man8.IsHonor);
        Assert.False(Tile.Man9.IsHonor);
        Assert.False(Tile.Pin1.IsHonor);
        Assert.False(Tile.Pin2.IsHonor);
        Assert.False(Tile.Pin3.IsHonor);
        Assert.False(Tile.Pin4.IsHonor);
        Assert.False(Tile.Pin5.IsHonor);
        Assert.False(Tile.Pin6.IsHonor);
        Assert.False(Tile.Pin7.IsHonor);
        Assert.False(Tile.Pin8.IsHonor);
        Assert.False(Tile.Pin9.IsHonor);
        Assert.False(Tile.Sou1.IsHonor);
        Assert.False(Tile.Sou2.IsHonor);
        Assert.False(Tile.Sou3.IsHonor);
        Assert.False(Tile.Sou4.IsHonor);
        Assert.False(Tile.Sou5.IsHonor);
        Assert.False(Tile.Sou6.IsHonor);
        Assert.False(Tile.Sou7.IsHonor);
        Assert.False(Tile.Sou8.IsHonor);
        Assert.False(Tile.Sou9.IsHonor);
    }

    [Fact]
    public void IsChuuchan_True()
    {
        Assert.True(Tile.Man2.IsChuuchan);
        Assert.True(Tile.Man3.IsChuuchan);
        Assert.True(Tile.Man4.IsChuuchan);
        Assert.True(Tile.Man5.IsChuuchan);
        Assert.True(Tile.Man6.IsChuuchan);
        Assert.True(Tile.Man7.IsChuuchan);
        Assert.True(Tile.Man8.IsChuuchan);
        Assert.True(Tile.Pin2.IsChuuchan);
        Assert.True(Tile.Pin3.IsChuuchan);
        Assert.True(Tile.Pin4.IsChuuchan);
        Assert.True(Tile.Pin5.IsChuuchan);
        Assert.True(Tile.Pin6.IsChuuchan);
        Assert.True(Tile.Pin7.IsChuuchan);
        Assert.True(Tile.Pin8.IsChuuchan);
        Assert.True(Tile.Sou2.IsChuuchan);
        Assert.True(Tile.Sou3.IsChuuchan);
        Assert.True(Tile.Sou4.IsChuuchan);
        Assert.True(Tile.Sou5.IsChuuchan);
        Assert.True(Tile.Sou6.IsChuuchan);
        Assert.True(Tile.Sou7.IsChuuchan);
        Assert.True(Tile.Sou8.IsChuuchan);
    }

    [Fact]
    public void IsChuuchan_False()
    {
        Assert.False(Tile.Man1.IsChuuchan);
        Assert.False(Tile.Man9.IsChuuchan);
        Assert.False(Tile.Pin1.IsChuuchan);
        Assert.False(Tile.Pin9.IsChuuchan);
        Assert.False(Tile.Sou1.IsChuuchan);
        Assert.False(Tile.Sou9.IsChuuchan);
        Assert.False(Tile.Ton.IsChuuchan);
        Assert.False(Tile.Nan.IsChuuchan);
        Assert.False(Tile.Sha.IsChuuchan);
        Assert.False(Tile.Pei.IsChuuchan);
        Assert.False(Tile.Haku.IsChuuchan);
        Assert.False(Tile.Hatsu.IsChuuchan);
        Assert.False(Tile.Chun.IsChuuchan);
    }

    [Fact]
    public void IsYaochuu_True()
    {
        Assert.True(Tile.Man1.IsYaochuu);
        Assert.True(Tile.Man9.IsYaochuu);
        Assert.True(Tile.Pin1.IsYaochuu);
        Assert.True(Tile.Pin9.IsYaochuu);
        Assert.True(Tile.Sou1.IsYaochuu);
        Assert.True(Tile.Sou9.IsYaochuu);
        Assert.True(Tile.Ton.IsYaochuu);
        Assert.True(Tile.Nan.IsYaochuu);
        Assert.True(Tile.Sha.IsYaochuu);
        Assert.True(Tile.Pei.IsYaochuu);
        Assert.True(Tile.Haku.IsYaochuu);
        Assert.True(Tile.Hatsu.IsYaochuu);
        Assert.True(Tile.Chun.IsYaochuu);
    }

    [Fact]
    public void IsYaochuu_False()
    {
        Assert.False(Tile.Man2.IsYaochuu);
        Assert.False(Tile.Man3.IsYaochuu);
        Assert.False(Tile.Man4.IsYaochuu);
        Assert.False(Tile.Man5.IsYaochuu);
        Assert.False(Tile.Man6.IsYaochuu);
        Assert.False(Tile.Man7.IsYaochuu);
        Assert.False(Tile.Man8.IsYaochuu);
        Assert.False(Tile.Pin2.IsYaochuu);
        Assert.False(Tile.Pin3.IsYaochuu);
        Assert.False(Tile.Pin4.IsYaochuu);
        Assert.False(Tile.Pin5.IsYaochuu);
        Assert.False(Tile.Pin6.IsYaochuu);
        Assert.False(Tile.Pin7.IsYaochuu);
        Assert.False(Tile.Pin8.IsYaochuu);
        Assert.False(Tile.Sou2.IsYaochuu);
        Assert.False(Tile.Sou3.IsYaochuu);
        Assert.False(Tile.Sou4.IsYaochuu);
        Assert.False(Tile.Sou5.IsYaochuu);
        Assert.False(Tile.Sou6.IsYaochuu);
        Assert.False(Tile.Sou7.IsYaochuu);
        Assert.False(Tile.Sou8.IsYaochuu);
    }

    [Fact]
    public void IsRoutou_True()
    {
        Assert.True(Tile.Man1.IsRoutou);
        Assert.True(Tile.Man9.IsRoutou);
        Assert.True(Tile.Pin1.IsRoutou);
        Assert.True(Tile.Pin9.IsRoutou);
        Assert.True(Tile.Sou1.IsRoutou);
        Assert.True(Tile.Sou9.IsRoutou);
    }

    [Fact]
    public void IsRoutou_False()
    {
        Assert.False(Tile.Man2.IsRoutou);
        Assert.False(Tile.Man3.IsRoutou);
        Assert.False(Tile.Man4.IsRoutou);
        Assert.False(Tile.Man5.IsRoutou);
        Assert.False(Tile.Man6.IsRoutou);
        Assert.False(Tile.Man7.IsRoutou);
        Assert.False(Tile.Man8.IsRoutou);
        Assert.False(Tile.Pin2.IsRoutou);
        Assert.False(Tile.Pin3.IsRoutou);
        Assert.False(Tile.Pin4.IsRoutou);
        Assert.False(Tile.Pin5.IsRoutou);
        Assert.False(Tile.Pin6.IsRoutou);
        Assert.False(Tile.Pin7.IsRoutou);
        Assert.False(Tile.Pin8.IsRoutou);
        Assert.False(Tile.Sou2.IsRoutou);
        Assert.False(Tile.Sou3.IsRoutou);
        Assert.False(Tile.Sou4.IsRoutou);
        Assert.False(Tile.Sou5.IsRoutou);
        Assert.False(Tile.Sou6.IsRoutou);
        Assert.False(Tile.Sou7.IsRoutou);
        Assert.False(Tile.Sou8.IsRoutou);
        Assert.False(Tile.Ton.IsRoutou);
        Assert.False(Tile.Nan.IsRoutou);
        Assert.False(Tile.Sha.IsRoutou);
        Assert.False(Tile.Pei.IsRoutou);
        Assert.False(Tile.Haku.IsRoutou);
        Assert.False(Tile.Hatsu.IsRoutou);
        Assert.False(Tile.Chun.IsRoutou);
    }

    [Fact]
    public void IsCompare_値が比較対象より小さいなら0未満の値が返る()
    {
        // Arrange
        var value = Tile.Man1;
        var other = Tile.Man2;

        // Act
        var actual = value.CompareTo(other);

        // Assert
        Assert.True(actual < 0);
    }

    [Fact]
    public void IsCompare_値が比較対象と等しいなら0が返る()
    {
        // Arrange
        var value = Tile.Man2;
        var other = Tile.Man2;

        // Act
        var actual = value.CompareTo(other);

        // Assert
        Assert.True(actual == 0);
    }

    [Fact]
    public void IsCompare_値が比較対象より大きいなら0超過の値が返る()
    {
        // Arrange
        var value = Tile.Man3;
        var other = Tile.Man2;

        // Act
        var actual = value.CompareTo(other);

        // Assert
        Assert.True(actual > 0);
    }

    [Fact]
    public void IsCompare_比較対象がnullのとき失敗()
    {
        // Arrange
        var man1 = Tile.Man1;

        // Act
        var ex = Record.Exception(() => man1.CompareTo(null));

        // Assert
        Assert.IsType<ArgumentNullException>(ex);
    }

    [Fact]
    public void LessThan()
    {
        // Arrange
        var left = Tile.Man1;
        var right = Tile.Man2;

        // Act
        var actual = left < right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThan_LeftIsNull()
    {
        // Arrange
        Tile? left = null;
        var right = Tile.Man2;

        // Act
        var actual = left < right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThan_LeftAndRightIsNull()
    {
        // Arrange
        Tile? left = null;
        Tile? right = null;

        // Act
        var actual = left < right;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void LessThanEqual_LessThanSide()
    {
        // Arrange
        var left = Tile.Man1;
        var right = Tile.Man2;

        // Act
        var actual = left <= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanEqual_EqualSide()
    {
        // Arrange
        var left = Tile.Man2;
        var right = Tile.Man2;

        // Act
        var actual = left <= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanEqual_LeftIsNull()
    {
        // Arrange
        Tile? left = null;
        var right = Tile.Man2;

        // Act
        var actual = left <= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanEqual_LeftAndRightIsNull()
    {
        // Arrange
        Tile? left = null;
        Tile? right = null;

        // Act
        var actual = left <= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MoreThan()
    {
        // Arrange
        var left = Tile.Man3;
        var right = Tile.Man2;

        // Act
        var actual = left > right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MoreThan_LeftIsNull()
    {
        // Arrange
        Tile? left = null;
        var right = Tile.Man2;

        // Act
        var actual = left > right;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void MoreThan_LeftAndRightIsNull()
    {
        // Arrange
        Tile? left = null;
        Tile? right = null;

        // Act
        var actual = left > right;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void MoreThanEqual_MoreThanSide()
    {
        // Arrange
        var left = Tile.Man3;
        var right = Tile.Man2;

        // Act
        var actual = left >= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MoreThanEqual_EqualSide()
    {
        // Arrange
        var left = Tile.Man2;
        var right = Tile.Man2;

        // Act
        var actual = left >= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MoreThanEqual_LeftIsNull()
    {
        // Arrange
        Tile? left = null;
        var right = Tile.Man2;

        // Act
        var actual = left >= right;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void MoreThanEqual_LeftAndRightIsNull()
    {
        // Arrange
        Tile? left = null;
        Tile? right = null;

        // Act
        var actual = left >= right;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ToString_成功()
    {
        Assert.Equal("一", Tile.Man1.ToString());
        Assert.Equal("二", Tile.Man2.ToString());
        Assert.Equal("三", Tile.Man3.ToString());
        Assert.Equal("四", Tile.Man4.ToString());
        Assert.Equal("五", Tile.Man5.ToString());
        Assert.Equal("六", Tile.Man6.ToString());
        Assert.Equal("七", Tile.Man7.ToString());
        Assert.Equal("八", Tile.Man8.ToString());
        Assert.Equal("九", Tile.Man9.ToString());
        Assert.Equal("(1)", Tile.Pin1.ToString());
        Assert.Equal("(2)", Tile.Pin2.ToString());
        Assert.Equal("(3)", Tile.Pin3.ToString());
        Assert.Equal("(4)", Tile.Pin4.ToString());
        Assert.Equal("(5)", Tile.Pin5.ToString());
        Assert.Equal("(6)", Tile.Pin6.ToString());
        Assert.Equal("(7)", Tile.Pin7.ToString());
        Assert.Equal("(8)", Tile.Pin8.ToString());
        Assert.Equal("(9)", Tile.Pin9.ToString());
        Assert.Equal("1", Tile.Sou1.ToString());
        Assert.Equal("2", Tile.Sou2.ToString());
        Assert.Equal("3", Tile.Sou3.ToString());
        Assert.Equal("4", Tile.Sou4.ToString());
        Assert.Equal("5", Tile.Sou5.ToString());
        Assert.Equal("6", Tile.Sou6.ToString());
        Assert.Equal("7", Tile.Sou7.ToString());
        Assert.Equal("8", Tile.Sou8.ToString());
        Assert.Equal("9", Tile.Sou9.ToString());
        Assert.Equal("東", Tile.Ton.ToString());
        Assert.Equal("南", Tile.Nan.ToString());
        Assert.Equal("西", Tile.Sha.ToString());
        Assert.Equal("北", Tile.Pei.ToString());
        Assert.Equal("白", Tile.Haku.ToString());
        Assert.Equal("發", Tile.Hatsu.ToString());
        Assert.Equal("中", Tile.Chun.ToString());
    }

    [Fact]
    public void ToString_失敗()
    {
        // Arrange
        var tile = new Tile(0);
        var propInfo = typeof(Tile).GetProperty("Id");
        propInfo?.SetValue(tile, -1);

        // Act
        var ex = Record.Exception(() => _ = tile.ToString());

        // Assert
        Assert.IsType<InvalidOperationException>(ex);
    }
}

// Arrange

// Act

// Assert
