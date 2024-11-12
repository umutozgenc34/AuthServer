

using System.Net;
using System.Text.Json.Serialization;

namespace Core.ReturnModels;

public class ReturnModel<TData>
{
     public TData? Data { get; set; }
     public List<string>? ErrorMessage { get; set; }
     public HttpStatusCode Status { get; set; }
     public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
     public bool IsFail => !IsSuccess;
     public string? UrlAsCreated { get; set; }


    public static ReturnModel<TData> Success(TData data, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ReturnModel<TData>()
        {
            Data = data,
            Status = status
        };
    }

    public static ReturnModel<TData> Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ReturnModel<TData>()
        {
            ErrorMessage = errorMessage,
            Status = status
        };
    }

    public static ReturnModel<TData> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ReturnModel<TData>()
        {
            ErrorMessage = [errorMessage],
            Status = status

        };
    }

}

public class ReturnModel
{

    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore] public HttpStatusCode Status { get; set; }
    [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    [JsonIgnore] public bool IsFail => !IsSuccess;


    public static ReturnModel Success(HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ReturnModel()
        {

            Status = status
        };
    }

    public static ReturnModel Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ReturnModel()
        {
            ErrorMessage = errorMessage,
            Status = status
        };
    }

    public static ReturnModel Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ReturnModel()
        {
            ErrorMessage = [errorMessage],
            Status = status

        };
    }
}
