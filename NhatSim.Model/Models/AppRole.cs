using Microsoft.AspNet.Identity.EntityFramework;

namespace NhatSim.Model.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {
        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public virtual string Description { get; set; }
    }
}