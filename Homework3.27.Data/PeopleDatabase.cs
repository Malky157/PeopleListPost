using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Homework3._27.Data
{
    public class PeopleDatabase
    {
        private string _connection { get; set; }
        public PeopleDatabase(string connection)
        {
            _connection = connection;
        }
        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connection);
            using var command = connection.CreateCommand();
            command.CommandText = $@"Select * From People";
            connection.Open();
            var reader = command.ExecuteReader();
            var people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person()
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }
        public void AddManyPeople(List<Person> peoples)
        {
            foreach (var person in peoples)
            {
                using var connection = new SqlConnection(_connection);
                using var command = connection.CreateCommand();
                command.CommandText = $@"Insert Into People(FirstName, LastName, Age)
                                      Values(@firstName, @lastName, @age)";
                command.Parameters.AddWithValue("@firstName", person.FirstName);
                command.Parameters.AddWithValue("@lastName", person.LastName);
                command.Parameters.AddWithValue("@age", person.Age);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
