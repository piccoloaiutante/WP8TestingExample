using OrangeCode.WpReborn.SQLiteApp.Db;

namespace OrangeCode.Wpreborn.SQLIteApp.Db.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Serial    { get; set; }
    }
}
