using DataAccessLayer.Interfaces;
using EntityLayer;
using EntityLayer.DTO_s;
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

        public List<JobAdvertisementDTO> GetAllActiveJobAdvertisements()
        {
            List<JobAdvertisementDTO> jobAdvertisements = new List<JobAdvertisementDTO>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllActiveJobAdvertisements", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobAdvertisement = new JobAdvertisementDTO
                    {
                        CompanyName= reader["CompanyName"].ToString(),
                        JobAdvertisementId = Convert.ToInt32(reader["JobAdvertisementId"]),
                        JobTitle = reader["JobTitle"].ToString()
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
                sqlCommand.Parameters.AddWithValue("@CityId", t.CityId);
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

        public JobAdvertisementDetailDTO GetJobAdvertisementDetailById(int JobAdvertisementId)
        {
            var jobAdvertisement = new JobAdvertisementDetailDTO();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetActiveJobAdvertisementById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobAdvertisement.CityName= reader["CityName"].ToString();
                        jobAdvertisement.CompanyName= reader["CompanyName"].ToString();
                        jobAdvertisement.CompanyWebsite= reader["CompanyWebsite"].ToString();
                        jobAdvertisement.JobDescription = reader["JobDescription"].ToString();
                        jobAdvertisement.JobTitle= reader["JobTitle"].ToString();
                        jobAdvertisement.MaxSalary = Convert.ToInt32(reader["MaxSalary"]);
                        jobAdvertisement.MinSalary = Convert.ToInt32(reader["MinSalary"]);
                        jobAdvertisement.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                    }
                }

                conn.Close();
                return jobAdvertisement;
            }
        }

        public int CheckIfUserAppliedJob(int JobAdvertisementId, int JobSeekerId)
        {
            int appliedNo;
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("CheckIfUserAppliedJob", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", JobSeekerId);
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                conn.Open();
                appliedNo = Convert.ToInt32(sqlCommand.ExecuteScalar());
                conn.Close();
                return appliedNo;
            }
        }
        public void ApplyJobAd(int JobAdvertisementId, int JobSeekerId)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("ApplyJobAd", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", JobSeekerId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<AppliedJobAdvertisementDTO> GetAppliedJobAdvertisements(int JobSeekerId)
        {
            List<AppliedJobAdvertisementDTO> jobAdvertisements = new List<AppliedJobAdvertisementDTO>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAppliedJobAdvertisements", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobSeekerId", JobSeekerId);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobAdvertisement = new AppliedJobAdvertisementDTO
                    {
                        CompanyName = reader["CompanyName"].ToString(),
                        ApplyDate=Convert.ToDateTime(reader["ApplyDate"]),
                        JobTitle = reader["JobTitle"].ToString()
                    };

                    jobAdvertisements.Add(jobAdvertisement);
                }

                reader.Close();
                conn.Close();
            }

            return jobAdvertisements;
        }

        public void DeactiveJobAdvertisement(int JobAdvertisementId)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("DeactiveJobAdvertisement", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void ActivateJobAdvertisement(int JobAdvertisementId)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("ActivateJobAdvertisement", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        public List<EmployerJobAdvertisementDTO> GetEmployerAllJobAdvertisements(int EmployerId)
        {
            List<EmployerJobAdvertisementDTO> jobAdvertisements = new List<EmployerJobAdvertisementDTO>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetEmployerAllJobAdvertisements", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployerId", EmployerId);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobAdvertisement = new EmployerJobAdvertisementDTO
                    {
                        CityId= Convert.ToInt32(reader["CityId"]),
                        JobAdvertisementId = Convert.ToInt32(reader["JobAdvertisementId"]),
                        JobTitle = reader["JobTitle"].ToString(),
                        CityName= reader["CityName"].ToString(),
                        EmployerId= Convert.ToInt32(reader["EmployerId"]),
                        IsActive=Convert.ToBoolean(reader["IsActive"]),
                        JobDescription= reader["JobDescription"].ToString(),
                        MaxSalary = Convert.ToInt32(reader["MaxSalary"]),
                        MinSalary = Convert.ToInt32(reader["MinSalary"]),
                        PublishDate= Convert.ToDateTime(reader["PublishDate"])
                    };

                    jobAdvertisements.Add(jobAdvertisement);
                }

                reader.Close();
                conn.Close();
            }

            return jobAdvertisements;
        }

        public List<CandidateDTO> GetAllUsersAppliedJob(int JobAdvertisementId)
        {
            List<CandidateDTO> jobAdvertisements = new List<CandidateDTO>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllUsersAppliedJob", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JobAdvertisementId", JobAdvertisementId);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var jobAdvertisement = new CandidateDTO
                    {
                        JobSeekerId = Convert.ToInt32(reader["JobSeekerId"]),
                        JobAdvertisementId = Convert.ToInt32(reader["JobAdvertisementId"]),
                        Email = reader["Email"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        ResumeId = Convert.ToInt32(reader["ResumeId"])
                    };

                    jobAdvertisements.Add(jobAdvertisement);
                }

                reader.Close();
                conn.Close();
            }

            return jobAdvertisements;
        }
    }
}
