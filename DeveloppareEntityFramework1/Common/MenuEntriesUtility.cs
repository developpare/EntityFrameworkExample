namespace DeveloppareEntityFramework.Common
{
    public static class MenuEntriesUtility
    {
        public static MenuEntries Menu { get; }
        static MenuEntriesUtility()
        {
            Menu = new MenuEntries();

            Menu.Entries.Add(new MenuEntry("home", "index", "Home"));
            Menu.Entries.Add(new MenuEntry("products", "index", "Lista Prodotti"));
            Menu.Entries.Add(new MenuEntry("product", "addproductpage", "Aggiungi Prodotto"));
        }
    }
    public class MenuEntries
    {
        public List<MenuEntry> Entries { get; }

        public MenuEntries()
        {
            Entries = new List<MenuEntry>();
        }
    }
    public class MenuEntry
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }

        public MenuEntry(string controller, string action, string text)
        {
            Controller = controller;
            Action = action;
            Text = text;
        }
    }
}
