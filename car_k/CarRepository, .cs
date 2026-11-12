using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace car_k
{
    internal class CarRepository_
    {
        private readonly string _connectionString;
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = @"
        CREATE TABLE IF NOT EXISTS Car (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            brand TEXT NOT NULL,
            model TEXT NOT NULL,
            Date TEXT NOT NULL,
            price REAL  NOT NULL
        );";
            using var command = new SqliteCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public void Add(Car car)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "INSERT INTO Car (brand, model,Date, price,)  VALUES(@brand, @model,@Date, @price); ";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@brand", car.brand);
            command.Parameters.AddWithValue("@model", car.model);
            command.Parameters.AddWithValue("@Date", car.Date);
            command.Parameters.AddWithValue("@price", car.price);
            command.ExecuteNonQuery();
        }
        public List<Car> GetAll()
        {
            var car = new List<Car>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "SELECT Id, brand, model, price, Date FROM Car;";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                car.Add(new Car
                {
                    Id = reader.GetInt32(0),
                    brand = reader.GetString(1),
                    model = reader.GetString(2),
                    Date = reader.GetDateTime(3),
                    price = reader.GetDecimal(4)
            
                });
            }
            return car;
        }
           
        public void Update(int Id,string model, string brand, double price=0)
        {           
            string sql = "UPDATE Car SET model = @Model, brend=@Brend, price=@Price WHERE Id = @Id";
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Model");
            command.Parameters.AddWithValue("@Brand");
            command.Parameters.AddWithValue("@Price");
            command.ExecuteNonQuery();
            
        }
        public void Delete(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = "Delete from Employees Where Id=@Id;";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

    }  
}

