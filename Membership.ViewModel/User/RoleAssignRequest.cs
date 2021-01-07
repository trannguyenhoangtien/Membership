using Membership.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.ViewModel.User
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
