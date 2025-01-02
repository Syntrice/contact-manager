namespace ContactManager.ApplicationOptions
{
    public sealed class DatabaseOptions
    {
        public const string SectionName = "DatabaseOptions";
        public string DatabasePath { get; set; } = "./contacts.db";
    }
}
