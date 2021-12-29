using EUCTask.Extensions;
using EUCTask.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace EUCTask.Models
{
    public class Registration
    {
        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        public string FullName { get; set; }
        [Display(Name = "BirthNumber", ResourceType = typeof(Resource))]
        [RequiredIf("BirthNumberNotSet", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        [RegularExpression(@"^[0-9]{6}/[0-9]{3,4}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "BirthNumberInvalid")]
        public string BirthNumber { get; set; }
        [Display(Name = "BirthNumberNotSet", ResourceType = typeof(Resource))]
        public bool BirthNumberNotSet { get; set; } = false;
        [Display(Name = "Birthday", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Gender", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        public string Gender { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }
        [Display(Name = "Nationality", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnRequiredField")]
        public string Nationality { get; set; }
        [Display(Name = "GdprAgreement", ResourceType = typeof(Resource))]
        [RequiredTrue(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WarnGDPR")]
        public bool GdprAgreement { get; set; }
    }
}
