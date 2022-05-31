namespace Plex.ServerApi.PlexModels.Account.SharedItems;

using System.Collections.Generic;

public class SharedItemAddModel
{
    public int InvitedId { get; set; }
    public List<SharedItemModelRequest> Items { get; set; } = new();
}

public class SharedItemModelRequest
{
    public string Uri { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
}
