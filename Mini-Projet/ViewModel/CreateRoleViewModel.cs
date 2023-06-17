using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.ViewModel
{
    public class CreateRoleViewModel
    {

        [Required]
        [Display(Name = "Role")]
        public string? RoleName { get; set; }
    }
}
