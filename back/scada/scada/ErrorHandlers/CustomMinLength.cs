using System.ComponentModel.DataAnnotations;

namespace scada.ErrorHandlers
{
    public class CustomMinLength : MinLengthAttribute
    {
        public string AttributeName { get; private set; }
        public int MinLength { get; private set; }

        public CustomMinLength(string attributeName, int minLength):base(minLength)
        {
            this.AttributeName = attributeName;
            this.MinLength = minLength;

        }
        public override string FormatErrorMessage(string name)
        {
            return $"{this.AttributeName} should have the atleast {this.MinLength} characters.";
        }


    }
}
