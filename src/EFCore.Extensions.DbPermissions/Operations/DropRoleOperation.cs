using EFCore.Extensions.DbPermissions.Core;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.SqlServer.Operations
{
    /// <summary>
    /// A <see cref="MigrationOperation" /> dropping a role
    /// </summary>
    public class DropRoleOperation : MigrationOperation, IDbPermissionOperation
    {
        /// <summary>
        /// The role to drop
        /// </summary>
        public string Role { get; }

        public DropRoleOperation(string role)
        {
            Role = role;
        }

        public void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .Append("DROP ROLE ")
                .Append(sqlHelper.DelimitIdentifier(Role))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
