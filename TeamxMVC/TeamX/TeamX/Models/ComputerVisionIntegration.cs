using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public static class ComputerVisionIntegration
{
    const string subscriptionKey = "e23b14f4b0e34742bf3ddb4b41efae7e";
    const string uriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";

    /// <summary>
    /// Gets a thumbnail image from the specified image file by using the Computer Vision REST API.
    /// </summary>
    /// <param name="imageFilePath">The image file to use to create the thumbnail image.</param>
    public static async Task<string> MakeAnalysisRequest(string imageFilePath)
    {
        HttpClient client = new HttpClient();

        // Request headers.
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

        string requestParameters = "visualFeatures=Categories,Description,Color&language=en";

        // Assemble the URI for the REST API Call.
        string uri = uriBase + "?" + requestParameters;

        HttpResponseMessage response;
        string responseContent;
        // Request body. Posts a locally stored JPEG image.
        byte[] byteData = GetImageAsByteArray(imageFilePath);

        using (ByteArrayContent content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            response = client.PostAsync(uri, content).Result;

            responseContent = response.Content.ReadAsStringAsync().Result;
        }
        return responseContent;
    }

    /// <summary>
    /// Returns the contents of the specified file as a byte array.
    /// </summary>
    /// <param name="imageFilePath">The image file to read.</param>
    /// <returns>The byte array of the image data.</returns>
    static byte[] GetImageAsByteArray(string imageFilePath)
    {
        FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        return binaryReader.ReadBytes((int)fileStream.Length);
    }
}