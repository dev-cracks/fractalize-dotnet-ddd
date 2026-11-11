using Fractalize.Ddd.SharedKernel.Audit;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Audit;

public class AuditLogProcessorConfiguratorTest
{
    [Fact]
    [UnitTest]
    public void ConfigureAuditLogProcessor_WithDefaultConfiguration_ResolvesAuditLogProcessor()
    {
        //Arrange
        var services = new ServiceCollection();
        services.ConfigureAuditLogProccesor();
        var provider = services.BuildServiceProvider();

        //Act
        var auditService= provider.GetRequiredService<IAuditLogProcessor>();

        //Assert
        Assert.NotNull(auditService);
    }
}
