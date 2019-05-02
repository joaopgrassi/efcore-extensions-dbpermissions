using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Extensions.DbPermissions.Operations
{
    public interface IDbPermissionMigrationCommand
    {
        void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies);
    }
}
