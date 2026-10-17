using Spectre.Console;

namespace Flashcards.UI
{
    public class MainMenu
    {

        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {

                var choise = AnsiConsole.Prompt(new SelectionPrompt<MainMenuChoices>()
                    .Title("Main Menu")
                    .UseConverter(c => c switch
                    {
                        MainMenuChoices.StartStudySession => "Start a study session",
                        MainMenuChoices.ManageStacks => "Manage Stacks",
                        MainMenuChoices.ManageFlashcards => "Manage Flashcards",
                        MainMenuChoices.Exit => "Exit"
                    })
                    .AddChoices(Enum.GetValues<MainMenuChoices>()));


                switch (choise)
                {
                    case MainMenuChoices.StartStudySession:
                        break;
                    case MainMenuChoices.ManageStacks:
                        break;
                    case MainMenuChoices.ManageFlashcards:
                        break;
                    case MainMenuChoices.Exit:
                        isRunning = false;
                        break;

                }
            }
        }
    }
}

enum MainMenuChoices
{
    StartStudySession,
    ManageStacks,
    ManageFlashcards,
    Exit
}
