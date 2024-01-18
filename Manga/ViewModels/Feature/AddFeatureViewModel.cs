namespace Manga_PL.ViewModels.Feature
{
    public class AddFeatureViewModel
    {
        public string Description { get; set; }
        public DateTime appearDate { get; set; }
        public DateTime? DisappearDate { get; set;}
        public int CharacterId { get; set; }
    }
}
