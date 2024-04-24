using System.Data.SQLite;
using TManager.entity;
using Task = TManager.entity.Task;

namespace TManager.repository
{
    public class TaskRepository
    {
        const string CONNECTION_STRING = "Data Source=tmanager.db;Version=3;New=True;Compress=True;";
        public TaskRepository()
        {

        }

        public virtual Task Save(Task task)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO tasks(id, name, assigned, started, pr_sent, merged, closed, done, status, deadline, note, user_id) VALUES" +
                    "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11})",
                    task.Id,
                    task.Name,
                    task.Assigned == null ? "" : task.Assigned.ToString(),
                    task.Started == null ? "" : task.Started.ToString(),
                    task.PrSent == null ? "" : task.PrSent.ToString(),
                    task.Merged == null ? "" : task.Merged.ToString(),
                    task.Closed == null ? "" : task.Closed.ToString(),
                    task.Done == null ? "" : task.Done.ToString(),
                    task.Status.ToString(),
                    task.Deadline.ToString(),
                    task.Note,
                    task.User.Id);
                cmd.ExecuteNonQuery();
            }
            return task;
        }

        public virtual void PartialUpdate(Task oldTask, Task task)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("UPDATE tasks SET id = '{0}', " +
                    "name = '{1}'," +
                    "assigned = '{2}'," +
                    "started = '{3}'," +
                    "pr_sent= '{4}'," +
                    "merged = '{5}'," +
                    "closed = '{6}'," +
                    "done = '{7}'," +
                    "status = '{8}'," +
                    "deadline = '{9}'," +
                    "note = '{10}'," +
                    "user_id = {11} " +
                    "WHERE id = '{12}' AND " +
                    "name = '{13}'",
                    task.Id,
                    task.Name,
                    task.Assigned == null ? "" : task.Assigned.ToString(),
                    task.Started == null ? "" : task.Started.ToString(),
                    task.PrSent == null ? "" : task.PrSent.ToString(),
                    task.Merged == null ? "" : task.Merged.ToString(),
                    task.Closed == null ? "" : task.Closed.ToString(),
                    task.Done == null ? "" : task.Done.ToString(),
                    task.Status.ToString(),
                    task.Deadline.ToString(),
                    task.Note,
                    task.User.Id,
                    oldTask.Id,
                    oldTask.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public virtual List<Task> GetAllByUserId(int userId)
        {
            List<Task> tasks = new List<Task>();
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM tasks LEFT JOIN users ON tasks.user_id = users.id WHERE tasks.user_id = {0}", userId);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(reader.GetInt16(12), reader.GetString(13));
                        Task task = new Task(reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2) != null ? reader.GetString(2) : "",
                            string.IsNullOrEmpty(reader.GetString(3)) ? "" : reader.GetString(3),
                            string.IsNullOrEmpty(reader.GetString(4)) ? "" : reader.GetString(4),
                            string.IsNullOrEmpty(reader.GetString(5)) ? "" : reader.GetString(5),
                            string.IsNullOrEmpty(reader.GetString(6)) ? "" : reader.GetString(6),
                            string.IsNullOrEmpty(reader.GetString(7)) ? "" : reader.GetString(7),
                            reader.GetString(8),
                            string.IsNullOrEmpty(reader.GetString(9)) ? "" : reader.GetString(9).ToString(),
                            reader.GetString(10));
                        task.User = user;
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }

        public virtual bool ExistsByIdAndName(string taskId, string name)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT COUNT (*) FROM tasks WHERE tasks.id = '{0}' AND tasks.name = '{1}'", taskId, name);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public virtual void Delete(string taskId, string taskName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("DELETE FROM tasks WHERE tasks.id = '{0}' AND tasks.name = '{1}'", taskId, taskName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
