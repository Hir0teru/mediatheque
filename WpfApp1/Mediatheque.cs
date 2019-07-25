using System;
using System.Collections.Generic;

public class Mediatheque
{
    private List<Media> medias = new List<Media>();


    public Mediatheque()
	{

	}

    public void addMedia(Media media)
    {
        medias.Add(media);
    }

    public void removeMedia(int index)
    {
        medias.RemoveAt(index);
    }

    public List<Media> getMedias() { return medias; }
}
