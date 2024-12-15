using System.Net;
using System.Text;
using System.Text.Json;

namespace GeminiAPI.Demo;
public static class Program {

	static string Url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

	// gemini api key at https://aistudio.google.com/app/apikey
	static string APIKey = "XXXXXXXX";

	static async Task Main() {
		// set proxy if needed
		// HttpClient.DefaultProxy = new WebProxy("http://127.0.0.1:7890");

		string userMessage = "Print Hello World with C#";

		// build http request content json
		GeminiRequestJsonRoot geminiRequestJson = GeminiAPIUtils.BuildRequestJson(userMessage);
		string geminiRequestJsonStr = JsonSerializer.Serialize(geminiRequestJson);

		// send http post and get response
		string responseContent = await GeminiHttpPostAsync(geminiRequestJsonStr);

		// deserialize http response content json
		GeminiResponseJsonRoot? geminiResponseJson = JsonSerializer.Deserialize<GeminiResponseJsonRoot>(responseContent);

		// load gemini's message from json
		string geminiMessage = GeminiAPIUtils.GetGeminiMessage(geminiResponseJson);

		Console.WriteLine(geminiMessage);
	}

	static async Task<string> GeminiHttpPostAsync(string geminiRequestJsonStr) {
		// add key to api url
		var fullUrl = $"{Url}?key={APIKey}";
		
		using (HttpClient client = new HttpClient()) {
			var httpContent = new StringContent(geminiRequestJsonStr, Encoding.UTF8, "application/json");

			// http post
			HttpResponseMessage response = await client.PostAsync(fullUrl, httpContent);

			// check success status
			if (response.IsSuccessStatusCode) {
				// read http response
				string responseContent = await response.Content.ReadAsStringAsync();
				return responseContent;
			} else {
				throw new Exception();
			}
		}
	}
}
