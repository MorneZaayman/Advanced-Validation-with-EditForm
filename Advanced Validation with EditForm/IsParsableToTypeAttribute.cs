using System.ComponentModel.DataAnnotations;

namespace Advanced_Validation_with_EditForm
{
    public sealed class IsParsableToTypeAttribute<T>() : ValidationAttribute(DefaultErrorMessage) where T : IParsable<T>
    {
        private static readonly string DefaultErrorMessage = "The {0} field is not parsable to type '" + typeof(T).FullName + "'";

        public override bool IsValid(object value)
        {
            return value is string valueAsString
                   && T.TryParse(valueAsString, null, out _);
        }
    }
}
