namespace _130926_Kuharica_Project.Middleware
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } 

        public string? TraceId { get; set; }

    }
}
