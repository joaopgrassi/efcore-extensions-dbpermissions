using EFCore.Extensions.DbPermissions.Core;
using EFCore.Extensions.DbPermissions.SqlServer.Operations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Extensions.DbPermissions.SqlServer
{
    public static class SqlServerMigrationBuilderExtensions
    {
        public static MigrationBuilder CreateRole(
            this MigrationBuilder migrationBuilder,
            string role)
        {
            migrationBuilder.Operations.Add(
                new CreateRoleOperation(role));

            return migrationBuilder;
        }

        public static MigrationBuilder DropRole(
            this MigrationBuilder migrationBuilder,
            string role)
        {
            migrationBuilder.Operations.Add(
                new DropRoleOperation(role));

            return migrationBuilder;
        }

        public static MigrationBuilder GrantToRole(
            this MigrationBuilder migrationBuilder,
            string table,
            string role,
            DbPermissionsEnum permission)
        {
            migrationBuilder.Operations.Add(
                new GrantToRoleOperation(table, role, permission));

            return migrationBuilder;
        }

        public static MigrationBuilder RevokeFromRole(
            this MigrationBuilder migrationBuilder,
            string table,
            string role,
            DbPermissionsEnum permission)
        {
            migrationBuilder.Operations.Add(
                new RevokeFromRoleOperation(table, role, permission));

            return migrationBuilder;
        }
    }
}
