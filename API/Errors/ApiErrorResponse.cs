namespace API.Errors;

public class ApiErrorResponse(int statusCode, string message, string? Details)
{
    public int StatusCode { get; set; } = statusCode;

    public string Message { get; set; } = message;

    public string? Details { get; set; } = Details;
}