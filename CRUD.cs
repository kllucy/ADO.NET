using Microsoft.Data.Sqlite;

namespace EmployeeApp
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = @"
                CREATE TABLE IF NOT EXISTS Employees (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Position TEXT NOT NULL,
                Salary REAL NOT NULL
                );";

            using var command = new SqliteCommand(query, connection);
            command.ExecuteNonQuery();
        }
        //CREATE
        public void Add(Employee employee)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "INSERT INTO Employees (Name, Position, Salary) VALUES (@Name, @Position, @Salary) ";
            using var command = new SqliteCommand( query, connection);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Position", employee.Position);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            command.ExecuteNonQuery();
        }
        //READ
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "SELECT Id, Name, Position, Salary FROM Employees;";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Position = reader.GetString(2),
                    Salary = reader.GetDecimal(3)
                });
            }
            return employees;
        }
        //Delete
        public void Delete(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "Delete from Employees Where Id=@Id;";
            using var command = new SqliteCommand (query , connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery (); 
        }
    }
}
