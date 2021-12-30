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
    public class AdoSkillRepository : ISkillDal
    {
        public void Add(Skill t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("AddSkill", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", t.ResumeId);
                sqlCommand.Parameters.AddWithValue("@SkillName", t.SkillName);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(Skill t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("DeleteSkill", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SkillId", t.SkillId);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Skill> GetAll()
        {
            List<Skill> skills = new List<Skill>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetAllSkills", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var skill = new Skill
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        SkillName = reader["SkillName"].ToString(),
                        SkillId = Convert.ToInt32(reader["SkillId"])
                    };

                    skills.Add(skill);
                }

                reader.Close();
                conn.Close();
            }

            return skills;
        }

        public Skill GetById(int id)
        {
            var skill = new Skill();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetSkillById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SkillId", id);
                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        skill.ResumeId = Convert.ToInt32(reader["ResumeId"]);
                        skill.SkillName = reader["SkillName"].ToString();
                        skill.SkillId = Convert.ToInt32(reader["SkillId"]);
                    }
                }

                conn.Close();
                return skill;
            }
        }

        public List<Skill> GetUserAllSkills(int resumeId)
        {
            List<Skill> skills = new List<Skill>();
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                var sqlCommand = new SqlCommand("GetUserAllSkills", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResumeId", resumeId);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var skill = new Skill
                    {
                        ResumeId = Convert.ToInt32(reader["ResumeId"]),
                        SkillName = reader["SkillName"].ToString(),
                        SkillId = Convert.ToInt32(reader["SkillId"])
                    };

                    skills.Add(skill);
                }

                reader.Close();
                conn.Close();
            }

            return skills;
        }

        public void Update(Skill t)
        {
            using (var conn = new SqlConnection(MSSQLConnectionString.connString))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateSkill", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SkillId", t.SkillId);
                sqlCommand.Parameters.AddWithValue("@SkillName", t.SkillName);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
