using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoUserRepository : IUserDal
    {
        public void Add(User t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddUser", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", t.Email);
                sqlCommand.Parameters.AddWithValue("@Password", t.Password);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(User t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteUser", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllUsers", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Email = reader["Email"].ToString(),
                        Password= reader["Password"].ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        CreateDate= Convert.ToDateTime(reader["CreateDate"])
                        
                    };
                    users.Add(user);
                }

                reader.Close();
                conn.Close();
            }

            return users;
        }

        public User GetById(int id)
        {
            var user = new User();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetUserById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("UserId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.UserId = Convert.ToInt32(reader["UserId"]);
                        user.Email = reader["Email"].ToString();
                        user.Password= reader["Password"].ToString();
                        user.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        user.IsActive = Convert.ToBoolean((reader["IsActive"]));
                    }
                }

                conn.Close();
                return user;
            }
        }

        public void Update(User t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateUser", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", t.Email);
                sqlCommand.Parameters.AddWithValue("@Password", t.Password);
                sqlCommand.Parameters.AddWithValue("@IsActive", t.IsActive);
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
