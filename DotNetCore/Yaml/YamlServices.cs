// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Company:...... J.H. Kelly
// Department:... Virtual Construction Services
// Website:...... http://www.jhkelly.com
// Solution:..... Sandbox
// Project:...... DotNetCore
// File:......... YamlServices.cs ✓✓
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

namespace DotNetCore.Yaml;

using YamlDotNet.RepresentationModel;

public class YamlServices
{

    public void DeduplicateTags(FileInfo fileInfo)
    {
        var content = File.ReadAllText(fileInfo.ToString());

        var fileInfoNew = fileInfo;


        // Split the content into YAML header and body
        var yamlEnd = content.IndexOf("---", 3); // Find the second '---' to separate YAML header

        if (yamlEnd == -1)
        {
            Console.WriteLine("Invalid Markdown file format. YAML header not found.");

            return;
        }

        var yamlHeader = content.Substring(3, yamlEnd - 3).Trim();
        var body = content.Substring(yamlEnd + 3).Trim();


        // Parse YAML header
        var input = new StringReader(yamlHeader);
        var yamlStream = new YamlStream();
        yamlStream.Load(input);


        // Find and deduplicate tags
        var rootMappingNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;

        var yamlScalarNode = new YamlScalarNode("tags");

        if (rootMappingNode.Children[yamlScalarNode] is not YamlScalarNode tagsNode)
        {
            throw new ArgumentNullException(nameof(tagsNode));
        }

        if (tagsNode.Value is not { Length: > 0 })
        {
            return;
        }

        var collection = tagsNode.Value.Split(", ");

        var tags = new HashSet<string>(collection);

        tagsNode.Value = string.Join(",", tags);


        // Rename Old
        File.Move(fileInfo.Name, "Dirty_" + fileInfo.Name);


        // Save New
        var newPath = Path.Combine(fileInfoNew.DirectoryName, "Cleaned_" + fileInfoNew.Name);

        using TextWriter writer = File.CreateText(newPath);

        writer.WriteLine("---");
        yamlStream.Save(writer, false);
        writer.WriteLine("---");
        writer.Write(body);
    }

}