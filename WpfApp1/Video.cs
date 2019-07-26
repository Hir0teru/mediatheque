using MetadataExtractor;
using System;
using System.Collections.Generic;

public class Video : Media
{
    private string duration = string.Empty;

	public Video(string path) : base(path)
	{
        IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(path);
        foreach (var directory in directories)
        {
            foreach (var tag in directory.Tags)
            {
                ///System.Diagnostics.Debug.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");
                if (string.Equals(directory.Name, "QuickTime Movie Header") && string.Equals(tag.Name, "Duration"))
                    duration = tag.Description;
            }

            if (directory.HasError)
            {
                foreach (var error in directory.Errors)
                    System.Diagnostics.Debug.WriteLine($"ERROR: {error}");
            }
        }
    }

    public string getDuration() { return duration; }
}
