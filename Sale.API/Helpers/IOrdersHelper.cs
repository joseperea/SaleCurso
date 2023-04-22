using Sale.Shared.Responses;

namespace Sale.API.Helpers
{
    public interface IOrdersHelper
    {
        Task<Response> ProcessOrderAsync(string email, string remarks);
    }
}
