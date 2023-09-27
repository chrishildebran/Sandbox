// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Company:...... J.H. Kelly
// Department:... Virtual Construction Services
// Website:...... http://www.jhkelly.com
// Solution:..... Sandbox
// Project:...... DotNetCore
// File:......... MarkdownService.cs ✓✓
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

namespace DotNetCore.Markdown;

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
            Console.WriteLine(++i + ") File: " + fileInfo);

            DeduplicateCommaSeparatedTags(fileInfo);
        }
    }

    /// <summary>
    ///     Finds all actual hashtags in a file, lower case, de-duplicate and write to bottom of file
    /// </summary>
    /// <param name="fileInfo"></param>
    public void ConsolidateTags(FileInfo fileInfo)
    {
        var lines = File.ReadLines(fileInfo.ToString()).ToList();

        foreach (var line in lines) { }
    }

    /// <summary>
    ///     De-duplicates tags previously ruled by YAML header.
    /// </summary>
    /// <param name="fileInfo"></param>
    public void DeduplicateCommaSeparatedTags(FileInfo fileInfo)
    {
        var searchString = "tags:";

        var lines = File.ReadLines(fileInfo.ToString()).ToList();

        var linesNew = string.Empty;

        foreach (var line in lines)
        {
            if (line.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                linesNew += line + '\n';

                continue;
            }

            var actualTagSegment = line.Remove(0, searchString.Length);

            if (actualTagSegment.Trim().Length <= 0 || actualTagSegment.IsNullOrEmpty())
            {
                linesNew += line + '\n';

                continue;
            }

            var distinctTags = actualTagSegment.Replace('#', ' ').ToLower().Split(',').Distinct();

            var tagstring = searchString;

            foreach (var distinctTag in distinctTags)
            {
                tagstring += " #" + distinctTag.Trim() + " ";
            }

            linesNew += tagstring + '\n';
        }

        File.WriteAllText(fileInfo.ToString(), linesNew);
    }

}