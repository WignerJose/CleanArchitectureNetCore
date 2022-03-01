using FluentValidation.Results;

namespace CleanArchitecture.Aplication.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public IDictionary<string, string[]> Erros { get; set; }

        public ValidationException() : base("se presentaron muchos errores de validacion")
        {
            Erros = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Erros = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failure => failure.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
