using inferback.Domain.Enum;

namespace inferback.Domain.Response;

public class BaseResponse<T> : IBaseResponse<T> {
    public string Result { get; set; } = string.Empty;

    public StatusCode StatusCode { get; set; }

    public T? Data { get; set; }
}

public interface IBaseResponse<T> {
    T? Data { get; set; }

    public string Result { get; set; }

    public StatusCode StatusCode { get; set; }
}