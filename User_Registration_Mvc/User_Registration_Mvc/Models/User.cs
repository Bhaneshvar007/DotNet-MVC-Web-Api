using System.ComponentModel.DataAnnotations;

namespace User_Registration_Mvc.Models
{
    public class User
    {
        public int U_id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Invalid email format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits")]
        [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
        public string phoneNum { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country name cannot exceed 50 characters")]
        [MinLength(3, ErrorMessage = "Country name must be at least 3 characters")]
        public string country { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters")]
        [MinLength(3, ErrorMessage = "State name must be at least 3 characters")]
        public string state { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid pincode format")]
        public string pincode { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [StringLength(100, ErrorMessage = "Area name cannot exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Area name must be at least 3 characters")]
        public string area { get; set; }
    }
}
