using System.Security.Claims;

namespace Ris2022.Data.ViewModel
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<Claim>();
            Roles = new List<string>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public List<Claim> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
