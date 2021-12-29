using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoResumeRepository : IResumeDal
    {
        public void Add(Resume t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddResume", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", t.UserId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(Resume t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteResume", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", t.ResumeId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Resume> GetAll()
        {
            List<Resume> resumes = new List<Resume>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllResumes", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var resume = new Resume
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        UserId = Convert.ToInt32(reader["JobSeekerId"])
                    };

                    resumes.Add(resume);
                }

                reader.Close();
                conn.Close();
            }

            return resumes;
        }

        public Resume GetById(int id)
        {
            var resume = new Resume();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetResumeById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resume.ResumeId=Convert.ToInt32(reader["ResumeId"]);
                        resume.UserId = Convert.ToInt32(reader["JobSeekerId"]);
                    }
                }

                conn.Close();
                return resume;
            }
        }

        public void Update(Resume t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateResume", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", t.UserId);
                sqlCommand.Parameters.AddWithValue("@ResumeId", t.ResumeId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public int GetJobSeekerResumeId(int JobSeekerId)
        {
            int ResumeId;
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetJobSeekerResumeId", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", JobSeekerId);
                conn.Open();
                ResumeId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                conn.Close();
                return ResumeId;
            }
        }
    }
}
