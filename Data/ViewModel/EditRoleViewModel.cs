using System.ComponentModel.DataAnnotations;

namespace Ris2022.Data.ViewModel
{
    public class EditRoleViewModel
    {

        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string id { get; set; }

        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set; }
        
        public List<string> Users { get; set; } 


    }
}
