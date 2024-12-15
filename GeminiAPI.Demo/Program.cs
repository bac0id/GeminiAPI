using System.Net;
using System.Text;
using System.Text.Json;

namespace GeminiAPI.Demo;
public static class Program {

	static string Url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

	// gemini api key
	static string APIKey = "XXXXXXXXXXXX-AAAAAAAAAAAAAAAAAAAAAAAAAA";

	static async Task Main() {
		// set proxy
		// HttpClient.DefaultProxy = new WebProxy("http://x.x.x:xxx");
		string userMessage = "Print Hello World with C#";
		await GeminiAsync(userMessage);
	}

	static async Task GeminiAsync(string userMessage) {
		// add key to api url
		var fullUrl = $"{Url}?key={APIKey}";
		
		using (HttpClient client = new HttpClient()) {
			// build http request json
			GeminiRequestJsonRoot geminiRequestJson = GeminiAPIUtils.BuildRequestJson(userMessage);
			string geminiRequestJsonStr = JsonSerializer.Serialize(geminiRequestJson);
			var httpContent = new StringContent(geminiRequestJsonStr, Encoding.UTF8, "application/json");

			// http post
			HttpResponseMessage response = await client.PostAsync(fullUrl, httpContent);

			// check success status
			if (response.IsSuccessStatusCode) {
				// read http response
				string responseContent = await response.Content.ReadAsStringAsync();

				// read gemini 
				GeminiResponseJsonRoot? geminiResponseJson = JsonSerializer.Deserialize<GeminiResponseJsonRoot>(responseContent);
				string geminiReply = GeminiAPIUtils.GetGeminiMessage(geminiResponseJson);
				Console.WriteLine(geminiReply);
			} else {
				Console.WriteLine(response.StatusCode);
			}
		}
	}
}
