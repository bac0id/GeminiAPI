# GeminiAPI
Access Gemini chat with C#.

# Usage
```csharp
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
```
