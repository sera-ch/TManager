using System.Data.SQLite;
using User = TManager.entity.User;

namespace TManager.repository
{
    public class UserRepository
    {
        const string CONNECTION_STRING = "Data Source=tmanager.db;Version=3;New=True;Compress=True;";
        public UserRepository()
        {

        }

        public virtual User Save(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO users(id, name) VALUES ({0}, {1})",
                    user.Id,
                    user.Name);
                cmd.ExecuteNonQuery();
            }
            return user;
        }

        public virtual User? GetUser(int userId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM users WHERE users.id = {0}", userId);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    User user = new User(reader.GetInt16(0), reader.GetString(1));
                    return user;
                }
            }
        }

    }
}
