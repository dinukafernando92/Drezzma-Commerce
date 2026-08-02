namespace Drezzma.Application.Exceptions
{
    public class RequestValidationException:Exception
    {
        public  IEnumerable<string> Errors { get; }
        public RequestValidationException(IEnumerable<string> errors):base("One or more validation errors occurred.")
        {
            Errors = errors;    
        }
    }
}
