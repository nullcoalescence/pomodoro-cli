using Terminal.Gui;
using pomodoro_cli.Gui;

public class Program
{
    // Views
    private static Window topWin;

    private static View splashScreenView;

    static void Main(string[] args)
    {
        Application.Init();

        var top = Application.Top;

        // Create top level window
        topWin = new Window(
            new Rect(
                0,
                1,
                Application.Top.Frame.Width,
                Application.Top.Frame.Height - 1),
            "Pomodoro Timer");

        top.Add(topWin);

        // Create menu bar
        var menuBar = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("File", new MenuItem[]
            {
                new MenuItem("Start timer", "", () => { StartTimerClicked(); }),
                new MenuItem("About", "", () => { AboutClicked(); }),
                new MenuItem("Exit", "", () => { ExitClicked(); })
            })
        });

        top.Add(menuBar);

        // Splash screen
        splashScreenView = new View();
        splashScreenView.Height = Application.Top.Frame.Height - 1;
        splashScreenView.Width = Dim.Fill();

        var appLabel = new Label()
        {
            Text = "CLI Pomodoro Timer!!",
            X = Pos.Center(),
            Y = Pos.Center()
        };

        splashScreenView.Add(appLabel);

        topWin.Add(splashScreenView);

        Application.Run();

        Application.Shutdown();
    }

    // Allow other classes to change the window
    // @TODO - I'm sure there is a better way to do this...
    public static void ChangeWin(Window newWin)
    {
        topWin.Subviews.First().RemoveAll();
        topWin.Add(newWin);
    }

    // Menu clicks
    private static void StartTimerClicked()
    {
        //topWin.Subviews.First().RemoveAll();
        //topWin.Add(new TimerPromptWindow());
        ChangeWin(new TimerPromptWindow());
    }

    private static void AboutClicked()
    {
        MessageBox.Query("About", "terminal based pomodoro timer", "Ok");
    }

    private static void ExitClicked()
    {
        Application.Shutdown();
    }
}