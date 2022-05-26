namespace Plex.ServerApi.PlexModels.Account.SharedItems;

using System.Collections.Generic;

public class SharedItemContainer
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Name { get; set; }
    public int ServerId { get; set; }
    public string Status { get; set; }
    public int SharedItemsCount { get; set; }
    public string CreatedAt { get; set; }
    public string AccessToken { get; set; }

    public SharedItemUser Invited { get; set; }
    public SharedItemUser Owner { get; set; }

    public List<SharedItem> SharedItems { get; set; }
}
