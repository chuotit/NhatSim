using System.ComponentModel.DataAnnotations;

namespace NhatSim.Web.Models
{
    public class AppRoleViewModel
    {
        public string Id { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { set; get; }

        public string Description { set; get; }
    }
}