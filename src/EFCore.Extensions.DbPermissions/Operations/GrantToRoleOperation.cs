using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.Operations
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
        public DbPermissions Permission { get; }

        public GrantToRoleOperation(string table, string role, DbPermissions permission)
        {
            Table = table;
            Role = role;
            Permission = permission;
        }

        public void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies)
        {
            if (Permission == DbPermissions.None)
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
