using LibMahjong.Tiles;

namespace LibMahjong.Test.Tiles;

public class FuuroTest
{
    [Fact]
    public void コンストラクタ_チーなのに順子じゃないなら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new Fuuro(FuuroType.Chi, new(man: "124")));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void コンストラクタ_ポンなのに刻子じゃないなら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new Fuuro(FuuroType.Pon, new(man: "112")));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void コンストラクタ_暗槓なのに槓子じゃないなら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new Fuuro(FuuroType.Ankan, new(man: "111")));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void コンストラクタ_明槓なのに槓子じゃないなら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new Fuuro(FuuroType.Minkan, new(man: "111")));

        // Assert
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void コンストラクタ_副露種別が不正なら失敗()
    {
        // Act
        var ex = Record.Exception(() => _ = new Fuuro((FuuroType)(-1), new(man: "123")));

        // Assert
        Assert.IsType<NotImplementedException>(ex);
    }

    [Fact]
    public void チー()
    {
        var chi = new Fuuro(FuuroType.Chi, new(man: "123"));

        Assert.True(chi.IsChi);
        Assert.False(chi.IsPon);
        Assert.False(chi.IsKan);
        Assert.False(chi.IsAnkan);
        Assert.False(chi.IsMinkan);
        Assert.False(chi.IsNuki);
        Assert.True(chi.IsOpen);
    }

    [Fact]
    public void ポン()
    {
        var pon = new Fuuro(FuuroType.Pon, new(man: "111"));

        Assert.False(pon.IsChi);
        Assert.True(pon.IsPon);
        Assert.False(pon.IsKan);
        Assert.False(pon.IsAnkan);
        Assert.False(pon.IsMinkan);
        Assert.False(pon.IsNuki);
        Assert.True(pon.IsOpen);
    }

    [Fact]
    public void 暗槓()
    {
        var ankan = new Fuuro(FuuroType.Ankan, new(man: "1111"));

        Assert.False(ankan.IsChi);
        Assert.False(ankan.IsPon);
        Assert.True(ankan.IsKan);
        Assert.True(ankan.IsAnkan);
        Assert.False(ankan.IsMinkan);
        Assert.False(ankan.IsNuki);
        Assert.False(ankan.IsOpen);
    }

    [Fact]
    public void 明槓()
    {
        var minkan = new Fuuro(FuuroType.Minkan, new(man: "1111"));

        Assert.False(minkan.IsChi);
        Assert.False(minkan.IsPon);
        Assert.True(minkan.IsKan);
        Assert.False(minkan.IsAnkan);
        Assert.True(minkan.IsMinkan);
        Assert.False(minkan.IsNuki);
        Assert.True(minkan.IsOpen);
    }

    [Fact]
    public void 抜き()
    {
        var nuki = new Fuuro(FuuroType.Nuki, new(honor: "4"));

        Assert.False(nuki.IsChi);
        Assert.False(nuki.IsPon);
        Assert.False(nuki.IsKan);
        Assert.False(nuki.IsAnkan);
        Assert.False(nuki.IsMinkan);
        Assert.True(nuki.IsNuki);
        Assert.False(nuki.IsOpen);
    }

    [Fact]
    public void ToString_()
    {
        Assert.Equal("チー 123", new Fuuro(FuuroType.Chi, new(sou: "123")).ToString());
        Assert.Equal("ポン 111", new Fuuro(FuuroType.Pon, new(sou: "111")).ToString());
        Assert.Equal("暗槓 1111", new Fuuro(FuuroType.Ankan, new(sou: "1111")).ToString());
        Assert.Equal("明槓 1111", new Fuuro(FuuroType.Minkan, new(sou: "1111")).ToString());
        Assert.Equal("抜き 北", new Fuuro(FuuroType.Nuki, new(honor: "4")).ToString());
    }

    [Fact]
    public void ToString_失敗()
    {
        // Arrange
        var invalidFuuro = new Fuuro(FuuroType.Chi, new(sou: "123"));
        var propInfo = typeof(Fuuro).GetProperty(nameof(Fuuro.Type));
        propInfo?.SetValue(invalidFuuro, (FuuroType)(-1));

        // Act
        var ex = Record.Exception(() => _ = invalidFuuro.ToString());

        // Assert
        Assert.IsType<NotImplementedException>(ex);
    }
}

// Arrange

// Act

// Assert
