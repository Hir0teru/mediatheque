﻿using System;

public class Video
{
    private string duration = string.Empty;

	public Video(string path) : base(path)
	{
        Enumerable<Directory> directories = ImageMetadataReader.ReadMetadata(path);
        foreach (var directory in directories)
        {
            foreach (var tag in directory.Tags)
            {
                ///System.Diagnostics.Debug.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");
                if (string.Equals(directory.Name, "QuickTime Movie Header") && string.Equals(tag.Name, "Duration"))
                    dutation = tag.Description;
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
