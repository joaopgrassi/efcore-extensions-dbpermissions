using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.Operations
{
    public class RevokeFromRoleOperation : MigrationOperation, IDbPermissionMigrationCommand
    {
        public string Table { get; }
        public string Role { get; }
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
