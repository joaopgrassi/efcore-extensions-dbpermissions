using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Extensions.DbPermissions.Core
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
