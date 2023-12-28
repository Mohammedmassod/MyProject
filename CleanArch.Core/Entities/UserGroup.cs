using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class UserGroup: BaseEnity
    {

        public ICollection<User> Users { get; set; }
        public PermissionGroup PermissionGroups { get; set; }
        public int PermissionGroupId { get; set; }


    }
}
