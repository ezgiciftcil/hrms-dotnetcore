using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoJobSeekerRepository : IJobSeekerDal
    {
        public void Add(JobSeeker t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddJobSeeker", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                sqlCommand.Parameters.AddWithValue("@FirstName", t.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", t.LastName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", t.PhoneNumber);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(JobSeeker t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteJobSeeker", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<JobSeeker> GetAll()
        {
            List<JobSeeker> jobSeekers = new List<JobSeeker>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllJobSeekers", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobSeeker = new JobSeeker
                    {
                        UserId= Convert.ToInt32(reader["UserId"]),
                        FirstName= reader["FirstName"].ToString(),
                        LastName= reader["LastName"].ToString(),
                        PhoneNumber= reader["PhoneNumber"].ToString()
                    };

                    jobSeekers.Add(jobSeeker);
                }

                reader.Close();
                conn.Close();
            }

            return jobSeekers;
        }

        public JobSeeker GetById(int id)
        {
            var jobSeeker = new JobSeeker();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetJobSeekerById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobSeeker.UserId = Convert.ToInt32(reader["UserId"]);
                        jobSeeker.FirstName = reader["FirstName"].ToString();
                        jobSeeker.LastName = reader["LastName"].ToString();
                        jobSeeker.PhoneNumber = reader["PhoneNumber"].ToString();
                    }
                }

                conn.Close();
                return jobSeeker;
            }
        }

        public void Update(JobSeeker t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateJobSeeker", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", t.UserId);
                sqlCommand.Parameters.AddWithValue("@FirstName", t.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", t.LastName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", t.PhoneNumber);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
