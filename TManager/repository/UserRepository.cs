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
                cmd.CommandText = string.Format("INSERT INTO users(name, password) VALUES ('{0}', '{1}')",
                    user.Name,
                    user.Password);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format("SELECT * FROM users WHERE users.name = '{0}'", user.Name);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    user.Id = reader.GetInt32(0);
                }
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

        public virtual User? GetByUserName(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM users WHERE users.name = '{0}'", username);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    User user = new User(reader.GetInt16(0), reader.GetString(1));
                    user.Password = reader.GetString(2);
                    return user;
                }
            }
        }



        public virtual List<User> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM users");
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(new User(reader.GetInt16(0), reader.GetString(1)));
                    }

                    return users;
                }
            }
        }

    }
}
