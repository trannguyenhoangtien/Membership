using System.Collections.Generic;

namespace Membership.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
