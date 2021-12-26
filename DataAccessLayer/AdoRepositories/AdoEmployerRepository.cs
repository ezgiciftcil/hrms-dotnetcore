using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoEmployerRepository : IEmployerDal
    {
        public void Add(Employer t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddEmployer", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                sqlCommand.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                sqlCommand.Parameters.AddWithValue("@CompanyWebsite", t.CompanyWebsite);
                sqlCommand.Parameters.AddWithValue("@ContactNumber", t.ContactNumber);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(Employer t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteEmployer", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Employer> GetAll()
        {
            List<Employer> employers = new List<Employer>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllEmployers", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var employer = new Employer
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        CompanyName = reader["CompanyName"].ToString(),
                        CompanyWebsite = reader["CompanyWebsite"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                    };
                    employers.Add(employer);
                }

                reader.Close();
                conn.Close();
            }

            return employers;
        }

        public Employer GetById(int id)
        {
            var employer = new Employer();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetEmployerById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("UserId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employer.UserId = Convert.ToInt32(reader["UserId"]);
                        employer.CompanyName = reader["CompanyName"].ToString();
                        employer.CompanyWebsite = reader["CompanyWebsite"].ToString();
                        employer.ContactNumber = reader["ContactNumber"].ToString();
                    }
                }

                conn.Close();
                return employer;
            }
        }

        public void Update(Employer t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateEmployer", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                sqlCommand.Parameters.AddWithValue("@CompanyWebsite", t.CompanyWebsite);
                sqlCommand.Parameters.AddWithValue("@ContactNumber", t.ContactNumber);
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
