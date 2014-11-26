using System.ComponentModel.DataAnnotations;

namespace Dinamico.Models
{
    public class LogOnModel
    {
        [Display(Name = "OpenID")]
        public string OpenID { get; set; }
        
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}