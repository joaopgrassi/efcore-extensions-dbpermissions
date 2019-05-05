using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.Extensions.DbPermissions.Operations
{
    public class CreateRoleOperation : MigrationOperation, IDbPermissionMigrationCommand
    {
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
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .Append("CREATE ROLE ")
                .Append(sqlHelper.DelimitIdentifier(Role))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
