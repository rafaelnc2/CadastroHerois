using System.Net;

namespace CadastroHerois.Api.Outputs;

public class ApiDefaultOutput<T>
{
    public HttpStatusCode StatusCode { get; init; }
    public bool Success { get; init; }
    public T? Data { get; init; }
    public IEnumerable<string> Errors { get; init; } = Enumerable.Empty<string>();

    public ApiDefaultOutput()
    {

    }

    public ApiDefaultOutput(HttpStatusCode statusCode, bool success)
    {
        StatusCode = statusCode;
        Success = success;
    }

    public ApiDefaultOutput(HttpStatusCode statusCode, bool success, T data) : this(statusCode, success) => Data = data;

    public ApiDefaultOutput(HttpStatusCode statusCode, bool success, IEnumerable<string> errors) : this(statusCode, success) =>
        Errors = errors;

    public ApiDefaultOutput(HttpStatusCode statusCode, bool success, T data, IEnumerable<string> errors) : this(statusCode, success, data) =>
        Errors = errors;

    public ApiDefaultOutput<T> OkResponse(T data) => new ApiDefaultOutput<T>(HttpStatusCode.OK, true, data);

    public ApiDefaultOutput<T> CreatedResponse(T data) => new ApiDefaultOutput<T>(HttpStatusCode.Created, true, data);

    public ApiDefaultOutput<T> NotFoundResponse() => new ApiDefaultOutput<T>(HttpStatusCode.NotFound, true);

    public ApiDefaultOutput<T> BadRequestResponse(IEnumerable<string> errors) => new ApiDefaultOutput<T>(HttpStatusCode.BadRequest, false, errors);
}