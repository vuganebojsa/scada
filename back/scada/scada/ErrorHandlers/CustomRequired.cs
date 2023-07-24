using System.ComponentModel.DataAnnotations;

namespace scada.ErrorHandlers
{
    public class CustomRequired: RequiredAttribute
    {
        public string AttributeName { get; private set; }
        public CustomRequired(string attributeName)
        {
            this.AttributeName = attributeName;

        }
        public override string FormatErrorMessage(string name)
        {
            return $"{this.AttributeName} must be entered.";
        }


    }
}
