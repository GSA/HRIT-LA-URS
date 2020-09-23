namespace lmsextreg.ViewModels
{
    public class AvailableActionCardViewModel
    {
        public AvailableActionCardViewModel(string title, string text, string buttonLabel)
        {
            this.Title          = title;
            this.Text           = text;
            this.ButtonLabel    = buttonLabel;
        }

        public string Title         { get; }
        public string Text          { get;  }
        public string ButtonLabel   { get; }
    }
}