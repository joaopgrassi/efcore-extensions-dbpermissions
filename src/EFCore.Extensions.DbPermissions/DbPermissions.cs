using System;

namespace EFCore.Extensions.DbPermissions
{
    [Flags]
    public enum DbPermissions
    {
        None = 0,
        Select = 1,
        Insert = 2,
        Update = 4,
        Delete = 8,
        CRUD = Select | Insert | Update | Delete,
    }
}
