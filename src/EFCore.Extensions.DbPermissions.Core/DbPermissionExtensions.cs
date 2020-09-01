using System.Collections.Generic;
using System.Linq;

namespace EFCore.Extensions.DbPermissions.Core
{
    public static class DbPermissionExtensions
    {
        private static readonly IDictionary<DbPermissionsEnum, string> DbPermissionsSqlMapping = new Dictionary<DbPermissionsEnum, string>()
        {
            { DbPermissionsEnum.Insert, "INSERT" },
            { DbPermissionsEnum.Select, "SELECT" },
            { DbPermissionsEnum.Update, "UPDATE" },
            { DbPermissionsEnum.Delete, "DELETE" },
        };

        public static string GetSqlCommandByPermission(this DbPermissionsEnum permissions) =>
            string.Join(",", DbPermissionsSqlMapping.Where(x => (permissions & x.Key) != 0).Select(x => x.Value));
    }
}
