using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.Operations
{
    /// <summary>
    /// A <see cref="MigrationOperation" /> for revoking permissions from a role
    /// </summary>
    public class RevokeFromRoleOperation : MigrationOperation, IDbPermissionOperation
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

        public RevokeFromRoleOperation(string table, string role, DbPermissions permission)
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
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .Append("REVOKE ")
                .Append(Permission.GetSqlCommandByPermission())
                .Append($" ON {sqlHelper.DelimitIdentifier(Table)}")
                .Append($" FROM {sqlHelper.DelimitIdentifier(Role)}")
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
