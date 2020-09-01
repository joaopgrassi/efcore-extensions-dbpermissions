using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Extensions.DbPermissions.Operations
{
    /// <summary>
    /// A base interface for all db permission migration operations
    /// </summary>
    public interface IDbPermissionOperation
    {
        void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies);
    }
}
