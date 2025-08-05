using System.Collections.Generic;
using System.Linq;

namespace AuthDemo.Helpers
{
    public static class RoleHelper
    {
        public static bool IsAdmin(IEnumerable<string> roles)
            => roles.Any(r => r?.ToLower() == "admin");

        public static bool IsUser(IEnumerable<string> roles)
            => roles.Any(r => r?.ToLower() == "user");
        public static bool IsNhanVien(IEnumerable<string> roles)
           => roles.Any(r => r?.ToLower() == "nhanvien");
        public static bool HasBothAdminAndUser(IEnumerable<string> roles)
            => IsAdmin(roles) && IsUser(roles);
    }
} 