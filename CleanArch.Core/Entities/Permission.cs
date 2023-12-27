using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class Permission: BaseEnity
    {

        public PermissionGroup PermissionGroup { get; set; }

    }
}
