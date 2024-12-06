namespace ConsoleSideScroller
{
    public class MainMenu
    {
        public int SelectedMenu { get; private set; } = 0;

        private List<string> Menus = ["1.Start", "2.Exit"];



        public void Run(ConsoleKey key)
        {
            Console.Clear();

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (SelectedMenu > 0)
                        SelectedMenu--;
                    break;
                case ConsoleKey.DownArrow:
                    if (SelectedMenu < Menus.Count - 1)
                        SelectedMenu++;
                    break;
                default:
                    break;
            }

            RenderMenu();
        }



        private void RenderMenu()
        {
            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < Menus.Count; i++)
            {
                string prefix = (i == SelectedMenu) ? "▶ " : "   ";
                Console.WriteLine(prefix + Menus[i]);
            }
        }

        private void ExecuteMenu()
        {
            switch (SelectedMenu)
            {
                case 0:

                    break;
                case 1:
                    Console.WriteLine("Exit game");
                    return;
                default:
                    break;
            }
        }
    }
}
