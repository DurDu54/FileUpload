using Abp.Authorization;
using FileUpload.Authorization.Roles;
using FileUpload.Authorization.Users;

namespace FileUpload.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
