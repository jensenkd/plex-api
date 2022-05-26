namespace Plex.ServerApi.PlexModels.Account.SharedItems;

public class SharedItemUser
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Title { get; set; }
    public string Username { get; set; }
    public bool Restricted { get; set; }
    public string Thumb { get; set; }
}
