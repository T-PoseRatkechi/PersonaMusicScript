﻿namespace PersonaMusicScript.Library.Models.Music.Entries;

public class EventEntry : BaseEntry
{
    public EventEntry(FrameTable eventFrame)
        : base(eventFrame)
    {
        this.Name = $"Event: {eventFrame.Ids.MajorId} | {eventFrame.Ids.MinorId} | {eventFrame.Ids.PmdType}";
    }
}
