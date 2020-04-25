namespace Plex.Api.ResourceModels
{
    public class CollectionModel
    {
        public string RatingKey { get; set; }
        public string Key { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string TitleSort { get; set; }
        public string ContentRating { get; set; }
        public string Subtype { get; set; }
        public string CollectionMode { get; set; }
        public string CollectionSort { get; set; }
        public string Summary { get; set; }
        public int Index { get; set; }
        public string Thumb { get; set; }
        public int AddedAt { get; set; }
        public int UpdatedAt { get; set; }
        public int ChildCount { get; set; }
        public int MaxYear { get; set; }
        public int MinYear { get; set; }
    }
}