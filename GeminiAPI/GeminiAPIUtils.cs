namespace GeminiAPI; 
public static class GeminiAPIUtils {
	public static GeminiRequestJsonRoot BuildRequestJson(string userMessage) {
		GeminiRequestJsonRoot geminiRequestJson = new GeminiRequestJsonRoot();
		geminiRequestJson.contents = new GeminiRequestJsonRoot.Content[1];
		geminiRequestJson.contents[0] = new GeminiRequestJsonRoot.Content();
		geminiRequestJson.contents[0].parts = new GeminiRequestJsonRoot.Part[1];
		geminiRequestJson.contents[0].parts[0] = new GeminiRequestJsonRoot.Part();
		geminiRequestJson.contents[0].parts[0].text = userMessage;
		return geminiRequestJson;
	}

	public static string GetGeminiMessage(GeminiResponseJsonRoot geminiResponseJson) {
		return geminiResponseJson.candidates[0].content.parts[0].text;
	}
}
