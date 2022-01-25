namespace miniapi_webapi
{
    public interface IErrorResponse
    {
        string Message { get; }

        string MsgCode { get; }
    }
}
