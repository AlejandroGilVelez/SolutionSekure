using System.Net.Http;

namespace Sekure.DrivenAdapters.ApiService.Client
{
    public interface ISekureClient
    {
        HttpClient Client { get; }
    }
}
