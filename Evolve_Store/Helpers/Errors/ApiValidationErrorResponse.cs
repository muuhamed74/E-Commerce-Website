namespace Evolve_Store.Helpers.Errors
{
    public class ApiValidationErrorResponse : ApiResponce
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorResponse() : base(400)
        {
        }
    }
}
