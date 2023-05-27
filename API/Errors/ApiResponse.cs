namespace API.Erros
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }


        public ApiResponse(int status, string message = null)
        {
            Status = status;
            Message = message ?? GetDefaultMessageBasedOnStatus(status);
        }

        private string GetDefaultMessageBasedOnStatus(int status)
        {
            return status switch
            {
                400 => "400",
                401 => "401",
                404 => "404",
                500 => "500",
                _ => ""
            };
        }
    }
}