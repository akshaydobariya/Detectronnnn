using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            UserName = new List<string>();
        }
        public string RoleId { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public String RoleName { get; set; }
        public List<String> UserName { get; set; }
    }
}
