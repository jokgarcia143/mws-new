using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MWS.Web.Models
{
    public class EditRoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
