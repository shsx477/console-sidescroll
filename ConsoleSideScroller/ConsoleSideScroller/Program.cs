namespace ConsoleSideScroller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectedWindowIndex = 0;
            var mainMenu = new MainMenu();
            Stage stage = null;

            mainMenu.Run(ConsoleKey.None);

            while (true)
            {
                var key = ConsoleKey.None;

                if (Console.KeyAvailable)
                    key = Console.ReadKey(true).Key;

                switch (selectedWindowIndex)
                {
                    case 0:
                        if (key != ConsoleKey.None)
                        {
                            mainMenu.Run(key);

                            if (key == ConsoleKey.Enter)
                            {
                                switch (mainMenu.SelectedMenu)
                                {
                                    case 0:
                                        selectedWindowIndex = 1;
                                        stage = new Stage();
                                        Console.Clear();
                                        break;
                                    case 1:
                                        return;
                                }
                            }
                        }
                        break;
                    case 1:
                        if (!stage?.Run(key) ?? false)
                        {
                            selectedWindowIndex = 0;
                            mainMenu.Run(ConsoleKey.None);
                        }

                        break;
                    default:
                        break;
                }

                Thread.Sleep(70);
            }
        }
    }
}
