using SQLite;

namespace DataLayer
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsNew { get; }
    }
    public class Entity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool IsNew { get => Id > 0; }
    }
}
