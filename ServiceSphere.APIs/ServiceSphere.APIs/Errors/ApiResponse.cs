
namespace ServiceSphere.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode,string? message=null)
        {
            StatusCode=statusCode;
            Message=message?? GetMessageByStatusCode(statusCode);
        }

        private string? GetMessageByStatusCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "Bad Request , you made",
                401 => "You are unauthorized",
                404 => "Resources not found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
