using System;
public class Media
{
    private string path = string.Empty;
    private string size = string.Empty;
    private string fileName = string.Empty;
    private string detectedFileTypeName = string.Empty;
    private string fileModifiedDate = string.Empty;

	public Media(string path)
	{
        self.path = path;
        IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(path);
        foreach (var directory in directories)
        {
            foreach (var tag in directory.Tags)
            {
                ///System.Diagnostics.Debug.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");
                switch (tag.Name)
                {
                    case "File Size":
                        size = tag.Description;
                        break;
                    case "File Name":
                        fileName = tag.Description;
                        break;
                    case "Detected File Type Name":
                        detectedFileTypeName = tag.Description;
                        break;
                    case "File Modified Date":
                        fileModifiedDate = tag.Description;
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

    public string getPath() { return path; }
    public string getSize() { return size; }
    public string getFileName() { return fileName; }
    public string getDetectedFileTypeName() { return detectedFileTypeName; }
    public string getFileModifiedDate() { return fileModifiedDate; }
}
