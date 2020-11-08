using Touruta.Core.CustomEntities;

namespace Touruta.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public Metadata Meta { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
