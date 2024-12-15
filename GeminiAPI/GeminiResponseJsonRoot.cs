namespace GeminiAPI; 
public class GeminiResponseJsonRoot {
	public Candidate[] candidates { get; set; }
	public Usagemetadata usageMetadata { get; set; }
	public string modelVersion { get; set; }

	public class Usagemetadata {
		public int promptTokenCount { get; set; }
		public int candidatesTokenCount { get; set; }
		public int totalTokenCount { get; set; }
	}

	public class Candidate {
		public Content content { get; set; }
		public string finishReason { get; set; }
		public int index { get; set; }
		public Safetyrating[] safetyRatings { get; set; }
	}

	public class Content {
		public Part[] parts { get; set; }
		public string role { get; set; }
	}

	public class Part {
		public string text { get; set; }
	}

	public class Safetyrating {
		public string category { get; set; }
		public string probability { get; set; }
	}
}
