namespace DotNetCore.Markdown;

using System.Text;
using System.Text.RegularExpressions;

using Kelly.Domain.Core.WerkZeuge;

using Microsoft.IdentityModel.Tokens;

public class MarkdownService
{

	public MarkdownService(string directory)
	{
		var rootDirectory = new DirectoryInfo(directory);

		if (!rootDirectory.Exists)
		{
			return;
		}

		var fileInfos = rootDirectory.GetFiles("*.md", SearchOption.AllDirectories);

		var i = 0;

		foreach (var fileInfo in fileInfos)
		{
			if (i <= 10)
			{
				Console.WriteLine(++i + ") File: " + fileInfo);


				//this.DeduplicateCommaSeparatedTags(fileInfo);

				this.GroupTagsAtBottom(fileInfo);
			}
		}
	}

	/// <summary>
	///     De-duplicates tags previously ruled by YAML header. The line of tags must start with the string "tags:".
	/// </summary>
	/// <param name="fileInfo"></param>
	/// <param name="hasHashSymbol"></param>
	public void DeduplicateCommaSeparatedTags(FileInfo fileInfo)
	{
		var lineStartsWith = "tags:";

		var lines = File.ReadLines(fileInfo.ToString()).ToList();

		var linesNew = string.Empty;

		foreach (var line in lines)
		{
			IEnumerable<string> distinctTags;

			if (line.StartsWith(lineStartsWith, StringComparison.CurrentCultureIgnoreCase) == false)
			{
				linesNew += line + '\n';

				continue;
			}


			// Remove Search String
			var actualTagSegment = line.Remove(0, lineStartsWith.Length).Trim();


			// If there is NOT a string left, continue. May be a situation where tags start on next line or ??.
			if (actualTagSegment.Length <= 0 || actualTagSegment.IsNullOrEmpty())
			{
				linesNew += line + '\n';

				continue;
			}


			// BUild new tag string
			var tagstring = "tags:";

			var cleanedTags = actualTagSegment.ToLower().Replace(",", " ").Replace("\"", string.Empty).Replace("/", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty)
			                                  .Replace("#", string.Empty);

			distinctTags = cleanedTags.Split(' ').Distinct().Where(s => s.IsNullOrEmpty() == false).OrderBy(s => s);

			foreach (var distinctTag in distinctTags)
			{
				tagstring += " #" + distinctTag.Trim().NormalizeWhiteSpace();
			}

			linesNew += tagstring + '\n';
		}

		File.WriteAllText(fileInfo.ToString(), linesNew);
	}

	private void GroupTagsAtBottom(FileInfo fileInfo)
	{
		var oldLines = File.ReadLines(fileInfo.ToString()).ToList();

		var tags = new List<string>();

		var sb = new StringBuilder();

		var lineNumber = 0;

		foreach (var oldLine in oldLines)
		{
			var match = Regex.Match(oldLine, "#([\\w]{1,})");

			Console.WriteLine($"- Line {lineNumber++} Has a tag: {match.Success} ");

			if (match.Success)
			{
				var tag = match.Groups[0].ToString();

				tags.Add(tag);

				sb.AppendLine(oldLine.Replace(tag, string.Empty).NormalizeWhiteSpace());


				//Console.WriteLine($"- New Line: {sb} ");
			}
			else
			{
				sb.AppendLine(oldLine);


				//Console.WriteLine($"- Old Line: {oldLine} ");
			}
		}

		sb.AppendLine(string.Join(' ', tags));


		//Console.WriteLine(sb.ToString());

		//File.WriteAllText(fileInfo.ToString(), sb.ToString());
	}

}