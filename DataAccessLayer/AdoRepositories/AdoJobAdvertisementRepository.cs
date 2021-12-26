using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoRepositories
{
    public class AdoJobAdvertisementRepository : IJobAdvertisementDal
    {
        public void Add(JobAdvertisement t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddJobAdvertisement", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployerId", t.EmployerId);
                sqlCommand.Parameters.AddWithValue("@CityId", t.CityId);
                sqlCommand.Parameters.AddWithValue("@JobDescription", t.JobDescription);
                sqlCommand.Parameters.AddWithValue("@JobTitle", t.JobTitle);
                sqlCommand.Parameters.AddWithValue("@MaxSalary", t.MaxSalary);
                sqlCommand.Parameters.AddWithValue("@MinSalary", t.MinSalary);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(JobAdvertisement t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteJobAdvertisement", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", t.JobAdvertisementId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<JobAdvertisement> GetAll()
        {
            List<JobAdvertisement> jobAdvertisements = new List<JobAdvertisement>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllJobAdvertisements", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobAdvertisement = new JobAdvertisement
                    {
                        CityId = Convert.ToInt32(reader["CityId"]),
                        EmployerId= Convert.ToInt32(reader["EmployerId"]),
                        IsActive=Convert.ToBoolean(reader["IsActive"]),
                        JobAdvertisementId= Convert.ToInt32(reader["JobAdvertisementId"]),
                        JobDescription= reader["JobDescription"].ToString(),
                        JobTitle= reader["JobTitle"].ToString(),
                        MaxSalary= Convert.ToInt32(reader["MaxSalary"]),
                        MinSalary = Convert.ToInt32(reader["MinSalary"]),
                        PublishDate=Convert.ToDateTime(reader["PublishDate"])
                    };

                    jobAdvertisements.Add(jobAdvertisement);
                }

                reader.Close();
                conn.Close();
            }

            return jobAdvertisements;
        }

        public JobAdvertisement GetById(int id)
        {
            var jobAdvertisement = new JobAdvertisement();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetJobAdvertisementById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobAdvertisement.CityId = Convert.ToInt32(reader["CityId"]);
                        jobAdvertisement.EmployerId = Convert.ToInt32(reader["EmployerId"]);
                        jobAdvertisement.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        jobAdvertisement.JobAdvertisementId = Convert.ToInt32(reader["JobAdvertisementId"]);
                        jobAdvertisement.JobDescription = reader["JobDescription"].ToString();
                        jobAdvertisement.JobTitle = reader["JobTitle"].ToString();
                        jobAdvertisement.MaxSalary = Convert.ToInt32(reader["MaxSalary"]);
                        jobAdvertisement.MinSalary = Convert.ToInt32(reader["MinSalary"]);
                        jobAdvertisement.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                    }
                }

                conn.Close();
                return jobAdvertisement;
            }
        }

        public void Update(JobAdvertisement t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateJobAdvertisement", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IsActive", t.IsActive);
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", t.JobAdvertisementId);
                sqlCommand.Parameters.AddWithValue("@JobDescription", t.JobDescription);
                sqlCommand.Parameters.AddWithValue("@JobTitle", t.JobTitle);
                sqlCommand.Parameters.AddWithValue("@MinSalary", t.MinSalary);
                sqlCommand.Parameters.AddWithValue("@MaxSalary", t.MaxSalary);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
