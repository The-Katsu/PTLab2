using PTLab2.Infrastructure.Database;

namespace PTLab2.Tests.Common;
public abstract class TestBase : IDisposable
{
    protected readonly ShopDbContext ShopDbContext;

    public TestBase()
    {
        ShopDbContext = ShopDbContextFactory.Create();
    }


    public void Dispose()
    {
        ShopDbContextFactory.Destroy(ShopDbContext);
    }
}
