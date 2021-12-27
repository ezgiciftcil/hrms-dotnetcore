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
    public class AdoExperienceRepository : IExperienceDal
    {
        public void Add(Experience t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddExperience", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", t.ResumeId);
                sqlCommand.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                sqlCommand.Parameters.AddWithValue("@JobDescription", t.JobDescription);
                sqlCommand.Parameters.AddWithValue("@JobTitle", t.JobTitle);
                sqlCommand.Parameters.AddWithValue("@StartDate", t.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", t.EndDate);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(Experience t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteExperience", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExperienceId", t.ExperienceId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Experience> GetAll()
        {
            List<Experience> experiences = new List<Experience>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllExperiences", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var experience = new Experience
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        CompanyName = reader["CompanyName"].ToString(),
                        ExperienceId = Convert.ToInt32(reader["ExperienceId"]),
                        JobDescription = reader["JobDescription"].ToString(),
                        JobTitle = reader["JobTitle"].ToString(),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                    };

                    experiences.Add(experience);
                }

                reader.Close();
                conn.Close();
            }
            return experiences;
        }

        public Experience GetById(int id)
        {
            var experience = new Experience();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetExperienceById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExperienceId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        experience.ResumeId = Convert.ToInt32(reader["ResumeId"]);
                        experience.CompanyName = reader["CompanyName"].ToString();
                        experience.ExperienceId = Convert.ToInt32(reader["ExperienceId"]);
                        experience.JobDescription = reader["JobDescription"].ToString();
                        experience.JobTitle = reader["JobTitle"].ToString();
                        experience.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        experience.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    }
                }

                conn.Close();
                return experience;
            }
        }

        public void Update(Experience t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateExperience", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExperienceId", t.ExperienceId);
                sqlCommand.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                sqlCommand.Parameters.AddWithValue("@JobDescription", t.JobDescription);
                sqlCommand.Parameters.AddWithValue("@JobTitle", t.JobTitle);
                sqlCommand.Parameters.AddWithValue("@StartDate", t.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", t.EndDate);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
