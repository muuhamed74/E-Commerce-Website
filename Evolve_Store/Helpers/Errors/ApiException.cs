namespace Evolve_Store.Helpers.Errors
{
    public class ApiException : ApiResponce
    {
        public ApiException(int statuscode, string? statusmessage = null , String? Details = null) : base(statuscode, statusmessage)
        {
        }

        public string? Details { get; set; }
    }
}
