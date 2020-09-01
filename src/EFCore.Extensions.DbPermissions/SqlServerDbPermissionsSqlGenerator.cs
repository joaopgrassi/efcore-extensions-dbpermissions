using EFCore.Extensions.DbPermissions.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions
{
    public class SqlServerDbPermissionsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public SqlServerDbPermissionsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            IMigrationsAnnotationProvider migrationsAnnotations)
            : base(dependencies, migrationsAnnotations)
        {
        }

        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            if (operation is IDbPermissionOperation dbPermissionMigration)
            {
                dbPermissionMigration.BuildMigrationCommand(builder, Dependencies);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }
    }
}
