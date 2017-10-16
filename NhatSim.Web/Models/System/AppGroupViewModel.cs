using System.Collections.Generic;

namespace NhatSim.Web.Models
{
    public class AppGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<AppRoleViewModel> Roles { set; get; }
    }
}