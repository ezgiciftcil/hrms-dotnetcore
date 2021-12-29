using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoEducationRepository : IEducationDal
    {
        public void Add(Education t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddEducation", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", t.ResumeId);
                sqlCommand.Parameters.AddWithValue("@UniversityName", t.UniversityName);
                sqlCommand.Parameters.AddWithValue("@DepartmentName", t.DepartmentName);
                sqlCommand.Parameters.AddWithValue("@GPA", t.GPA);
                sqlCommand.Parameters.AddWithValue("@StartDate", t.StartDate);
                sqlCommand.Parameters.AddWithValue("@FinishDate", t.FinishDate);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(Education t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteEducation", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EducationId", t.EducationId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Education> GetAll()
        {
            List<Education> educations = new List<Education>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllEducations", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var education = new Education
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        EducationId = Convert.ToInt32(reader["EducationId"]),
                        UniversityName= reader["UniversityName"].ToString(),
                        GPA=Convert.ToDouble(reader["GPA"]),
                        StartDate=Convert.ToDateTime(reader["StartDate"]),
                        FinishDate = Convert.ToDateTime(reader["FinishDate"]),
                    };

                    educations.Add(education);
                }

                reader.Close();
                conn.Close();
            }

            return educations;
        }

        public Education GetById(int id)
        {
            var education = new Education();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetEducationById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EducationId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        education.ResumeId = Convert.ToInt32(reader["ResumeId"]);
                        education.DepartmentName = reader["DepartmentName"].ToString();
                        education.EducationId = Convert.ToInt32(reader["EducationId"]);
                        education.UniversityName = reader["UniversityName"].ToString();
                        education.GPA = Convert.ToDouble(reader["GPA"]);
                        education.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        education.FinishDate = Convert.ToDateTime(reader["FinishDate"]);
                    }
                }

                conn.Close();
                return education;
            }
        }

        public List<Education> GetUserAllEducations(int resumeId)
        {
            List<Education> educations = new List<Education>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetUserAllEducations", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", resumeId);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var education = new Education
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        EducationId = Convert.ToInt32(reader["EducationId"]),
                        UniversityName = reader["UniversityName"].ToString(),
                        GPA = Convert.ToDouble(reader["GPA"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        FinishDate = Convert.ToDateTime(reader["FinishDate"]),
                    };

                    educations.Add(education);
                }

                reader.Close();
                conn.Close();
            }

            return educations;
        }

        public void Update(Education t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateEducation", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EducationId", t.EducationId);
                sqlCommand.Parameters.AddWithValue("@UniversityName", t.UniversityName);
                sqlCommand.Parameters.AddWithValue("@DepartmentName", t.DepartmentName);
                sqlCommand.Parameters.AddWithValue("@GPA", t.GPA);
                sqlCommand.Parameters.AddWithValue("@StartDate", t.StartDate);
                sqlCommand.Parameters.AddWithValue("@FinishDate", t.FinishDate);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
