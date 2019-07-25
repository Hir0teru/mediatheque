using System;

public class ImageMedia : Media
{
    private string width = string.Empty;
    private string height = string.Empty;

	public ImageMedia(string path) : base(path)
	{
        Enumerable<Directory> directories = ImageMetadataReader.ReadMetadata(path);
        foreach (var directory in directories)
        {
            foreach (var tag in directory.Tags)
            {
                ///System.Diagnostics.Debug.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");
                switch (tag.Name)
                {
                    case "Image Width":
                        width = tag.Description;
                        break;
                    case "Image Height":
                        height = tag.Description;
                        break;
                }
            }

            if (directory.HasError)
            {
                foreach (var error in directory.Errors)
                    System.Diagnostics.Debug.WriteLine($"ERROR: {error}");
            }
        }
    }

    public string getWidth() { return width; }
    public string getHeight() { return height; }
}
