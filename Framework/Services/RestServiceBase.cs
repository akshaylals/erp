namespace Framework.Services;

public class RestServiceBase
{
    private HttpClient _httpClient;
    private IConnectivity _connectivity;

    protected RestServiceBase(IConnectivity connectivity)
    {
        this._connectivity = connectivity;
    }

    protected void SetBaseURL(string apiBaseUrl)
    {
        _httpClient = new()
        {
            BaseAddress = new Uri(apiBaseUrl)
        };

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
    }

    protected void AddHttpHeader(string key, string value) =>
    _httpClient.DefaultRequestHeaders.Add(key, value);

    protected async Task<T> GetAsync<T>(string resource)
    {
        var json = await GetJsonAsync(resource);
        return JsonSerializer.Deserialize<T>(json);
    }

    private async Task<string> GetJsonAsync(string resource)
    {
        //No Cache Found, or Cached data was not required, or Internet connection is also available
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            throw new InternetConnectionException();

        //Extract response from URI
        var response = await _httpClient.GetAsync(new Uri(_httpClient.BaseAddress, resource));

        //Check for valid response
        response.EnsureSuccessStatusCode();

        //Read Response
        string json = await response.Content.ReadAsStringAsync();

        //Return the result
        return json;
    }

    protected async Task<HttpResponseMessage> PostAsync<T>(string uri, T payload)
    {
        var dataToPost = JsonSerializer.Serialize(payload);
        var content = new StringContent(dataToPost, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(new Uri(_httpClient.BaseAddress, uri), content);

        response.EnsureSuccessStatusCode();

        return response;
    }

    protected async Task<HttpResponseMessage> PutAsync<T>(string uri, T payload)
    {
        var dataToPost = JsonSerializer.Serialize(payload);
        var content = new StringContent(dataToPost, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(new Uri(_httpClient.BaseAddress, uri), content);

        response.EnsureSuccessStatusCode();

        return response;
    }

    protected async Task<HttpResponseMessage> DeleteAsync(string uri)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(_httpClient.BaseAddress, uri));

        response.EnsureSuccessStatusCode();

        return response;
    }
}
