namespace PersonaMusicScript.Library.Models;

public class EventFrame
{
    public EventFrame(string eventFile)
    {
        this.EventFile = eventFile;
    }

    public string EventFile { get; }

    public List<EventFrameBgm> FrameBgms { get; } = new();
}
