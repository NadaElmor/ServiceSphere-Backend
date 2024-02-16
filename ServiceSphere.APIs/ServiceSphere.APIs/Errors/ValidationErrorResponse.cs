namespace ServiceSphere.APIs.Errors
{
    public class ValidationErrorResponse:ApiResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationErrorResponse():base(404)
        {
            
        }
    }
}
