using Terminal.Gui;

namespace pomodoro_cli.Gui 
{
    internal class TimerPromptWindow : Window
    {
        public TextField secondsField;

        public TimerPromptWindow()
        {
            this.Title = "Timer Prompt";

            // Labels
            var promptLabel = new Label()
            {
                Text = "Enter a time (seconds)",
                X = 0,
                Y = 0
            };

            // Seconds field
            this.secondsField = new TextField(" ")
            {
                //X = Pos.Right(promptLabel) + 1,
                Y = Pos.Bottom(promptLabel) + 1,
                Width = Dim.Fill()
            };

            // 'Go to timer' button
            var button = new Button()
            {
                Text = "Start timer",
                Y = Pos.Bottom(this.secondsField) + 2,
                X = Pos.Center(),
                IsDefault = true
            };

            // Button click
            button.Clicked += () =>
            {
                // Validation
                var secondsFieldValue = this.secondsField.Text.ToString();

                if (!int.TryParse(secondsFieldValue, out var seconds))
                {
                    MessageBox.ErrorQuery("Error", "Enter a time in seconds.\nEx:  45", "Try again");
                    this.secondsField.Text = "";
                    return;
                }

                MessageBox.Query("Start", $"Start timer for {secondsFieldValue} seconds!", "Ok");

            };

            // Add to view
            Add(promptLabel,
                this.secondsField,
                button);
        }
    }
}
