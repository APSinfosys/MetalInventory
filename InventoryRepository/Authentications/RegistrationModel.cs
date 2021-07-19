using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryRepository.Authentications
{
   public class RegistrationModel
    {
        public int RegId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyGST { get; set; }
        public string CompanyPan { get; set; }
        [EmailAddress]
        public string CompanyEmail { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyAlternetNo { get; set; }
        public int? RegType { get; set; }

        public int? RegStatus { get; set; }
        public int? CompanyCode { get; set; }
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "UserPassword")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ReUserPassword")]
        [Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ReUserPassword { get; set; }
        //public CommonTypesModel CommonTypes { get; set; }
    }
}
