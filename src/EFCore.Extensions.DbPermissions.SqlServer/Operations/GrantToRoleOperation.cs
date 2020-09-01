using EFCore.Extensions.DbPermissions.Core;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.SqlServer.Operations
{
    /// <summary>
    /// A <see cref="MigrationOperation" /> for granting permissions to a role
    /// </summary>
    public class GrantToRoleOperation : MigrationOperation, IDbPermissionOperation
    {
        /// <summary>
        /// The table name
        /// </summary>
        public string Table { get; }

        /// <summary>
        /// The role name
        /// </summary>
        public string Role { get; }

        /// <summary>
        /// The permissions to grant to the role
        /// </summary>
        public DbPermissionsEnum Permission { get; }

        public GrantToRoleOperation(string table, string role, DbPermissionsEnum permission)
        {
            Table = table;
            Role = role;
            Permission = permission;
        }

        public void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies)
        {
            if (Permission == DbPermissionsEnum.None)
                return;

            var sqlHelper = Dependencies.SqlGenerationHelper;

            // TODO: Add schema to table if it's passed

            builder
                .Append("GRANT ")
                .Append(Permission.GetSqlCommandByPermission())
                .Append($" ON {sqlHelper.DelimitIdentifier(Table)}")
                .Append($" TO {sqlHelper.DelimitIdentifier(Role)}")
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
