using System.Collections.Generic;
using System.Linq;

namespace EFCore.Extensions.DbPermissions
{
    public static class DbPermissionExtensions
    {
        private static readonly IDictionary<DbPermissions, string> DbPermissionsSqlMapping = new Dictionary<DbPermissions, string>()
        {
            { DbPermissions.Insert, "INSERT" },
            { DbPermissions.Select, "SELECT" },
            { DbPermissions.Update, "UPDATE" },
            { DbPermissions.Delete, "DELETE" },
        };

        public static string GetSqlCommandByPermission(this DbPermissions permissions) =>
            string.Join(",", DbPermissionsSqlMapping.Where(x => (permissions & x.Key) != 0).Select(x => x.Value));
    }
}
