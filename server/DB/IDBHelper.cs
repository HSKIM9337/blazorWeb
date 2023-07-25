namespace server.DB
{
    public interface IDBHelper
    {
        Task InitializeAsync();

        void insertIntoBoardTable(DateTime date, string title, string contents, string Email);
    }
}
