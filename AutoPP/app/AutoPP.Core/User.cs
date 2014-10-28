using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AutoPP.Core
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class User : Entity
    {
        public virtual Guid UserId { get; set; }
        [Display(Name="Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid email")]
        [Required]
        public virtual string UserName { get; set; }
        [Required]
        public virtual string Password { get; set; }
        [Required]
        [Display(Name="Confirm Password")]
        public virtual string ConfirmPassword { get; set; }
        
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PropertiesMustMatch : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";

        public PropertiesMustMatch(string OriginalProperty, string ConfirmProperty)
            : base(_defaultErrorMessage)
        {
            this.OriginalProperty = OriginalProperty;
            this.ConfirmProperty = ConfirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
                object originalValue = properties.Find(OriginalProperty,
                    true /* ignoreCase */).GetValue(value);
                object confirmValue = properties.Find(ConfirmProperty,
                    true /* ignoreCase */).GetValue(value);
                return Object.Equals(originalValue, confirmValue);
            }
            else
                return true;
        }
    }
}
