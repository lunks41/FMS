namespace FMS.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool success, string message, dynamic output)
        {
            Success = success;
            Message = message;
            Output = output;
        }
        public ResponseModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic? Output { get; set; }

        public static ResponseModel SuccessResponse(string message, dynamic output)
        {
            return new ResponseModel(true, message, output);
        }
        public static ResponseModel FailureResponse(string message)
        {
            return new ResponseModel(false, message);
        }

    }
    public class IncomeReponce
    {
        public int Id { get; set; }
        public string? No { get; set; }
        public string? Msg { get; set; }

    }

    public class SQLReponce
    {
        public int Id { get; set; }
        public string? Msg { get; set; }

    }
}
