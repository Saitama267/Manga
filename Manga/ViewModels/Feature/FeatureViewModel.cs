namespace Manga_PL.ViewModels.Feature
{
    public class FeatureViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateAppear { get; set; }

        public DateTime? DateDisappear { get; set; }
    }
}
