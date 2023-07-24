using System.ComponentModel.DataAnnotations;

namespace scada.ErrorHandlers
{
    public class CustomMaxLength : MaxLengthAttribute
    {
        public string AttributeName { get; private set; }
        public int MaxLength { get; private set; }
        public CustomMaxLength(string attributeName, int maxLength)
        {
            this.AttributeName = attributeName;
            this.MaxLength = maxLength;

        }
        public override string FormatErrorMessage(string name)
        {
            return $"{this.AttributeName} should have the less than {this.MaxLength} characters.";
        }


    }
}
