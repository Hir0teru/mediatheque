using System;

public class Mediatheque
{
    private List<Media> medias = new List<Media>();


    public Mediatheque()
	{

	}

    public void addMedia(Media media)
    {
        medias.add(media);
    }

    public void removeMedia(int index)
    {
        medias.RemoveAt(index);
    }

    public List<Media> getMedias() { return medias; }
}
