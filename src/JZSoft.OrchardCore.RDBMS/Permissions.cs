using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.Queries;
using OrchardCore.Security.Permissions;

namespace OrchardCore.RelationDb
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageRelationalDbTypes = new Permission(nameof(ManageRelationalDbTypes), "Manage Relational Database Types");
        public static readonly Permission SyncAllRelationalDbData = new Permission(nameof(SyncAllRelationalDbData), "Synchronization all relational Database");
         

        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            var list = new List<Permission> { ManageRelationalDbTypes, SyncAllRelationalDbData }; 
            return list;
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageRelationalDbTypes, SyncAllRelationalDbData }
                } 
            };
        }
 
    }
}
