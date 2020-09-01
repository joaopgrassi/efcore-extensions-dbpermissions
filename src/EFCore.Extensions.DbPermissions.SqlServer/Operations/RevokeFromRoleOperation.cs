using EFCore.Extensions.DbPermissions.Core;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.SqlServer.Operations
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
        public DbPermissionsEnum Permission { get; }

        public RevokeFromRoleOperation(string table, string role, DbPermissionsEnum permission)
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
