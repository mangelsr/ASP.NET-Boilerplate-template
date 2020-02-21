using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyProject.Authorization
{
    public class MyProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            
            // context.CreatePermission(PermissionNames.Pages_PhoneBook, L("PhoneBook"));

            var phoneBook = context.CreatePermission(PermissionNames.Pages_PhoneBook, L("PhoneBook"));
            phoneBook.CreateChildPermission(PermissionNames.Pages_PhoneBook_CreatePerson, L("CreateNewPerson"));
            phoneBook.CreateChildPermission(PermissionNames.Pages_PhoneBook_DeletePerson, L("DeletePerson"));
            phoneBook.CreateChildPermission(PermissionNames.Pages_PhoneBook_EditPerson, L("EditPerson"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        }
    }
}
