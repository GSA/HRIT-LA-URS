namespace lmsextreg.ViewModels
{
    public class AvailableActionCardViewModel
    {
        public AvailableActionCardViewModel(string title, string text, string buttonLabel, string onSubmit)
        {
            this.Title          = title;
            this.Text           = text;
            this.ButtonLabel    = buttonLabel;
            this.OnSubmit       = onSubmit;
        }

        public string Title         { get; }
        public string Text          { get; }
        public string ButtonLabel   { get; }
        public string OnSubmit      { get; }
    }
}