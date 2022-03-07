using ItemSchedule.Api.Test.Utilities;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItemSchedule.Api.Test.Extensions;

public static class HttpResponseMessageExtensions
{
    public static Task<T> DeserializeContent<T>(this HttpResponseMessage message)
    {
        return JsonUtils.DeserializeAsync<T>(message.Content.ReadAsStreamAsync());
    }
}