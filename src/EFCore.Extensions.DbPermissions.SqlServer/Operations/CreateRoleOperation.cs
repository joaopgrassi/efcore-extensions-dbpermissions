using EFCore.Extensions.DbPermissions.Core;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.SqlServer.Operations
{
    /// <summary>
    /// A <see cref="MigrationOperation" /> for creating a new role
    /// </summary>
    public class CreateRoleOperation : MigrationOperation, IDbPermissionOperation
    {
        /// <summary>
        /// The role name
        /// </summary>
        public string Role { get; }

        public CreateRoleOperation(string role)
        {
            Role = role;
        }

        public void BuildMigrationCommand(
            MigrationCommandListBuilder builder,
            MigrationsSqlGeneratorDependencies Dependencies)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;

            builder
                .Append("CREATE ROLE ")
                .Append(sqlHelper.DelimitIdentifier(Role))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
