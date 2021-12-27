﻿using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeDal _resumeDal;
        public ResumeService(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }
        public Result AddResume(Resume resume)
        {
            _resumeDal.Add(resume);
            return new Result(true);
        }

        public Result DeleteResume(Resume resume)
        {
            _resumeDal.Delete(resume);
            return new Result(true);
        }

        public DataResult<List<Resume>> GetAllResumes()
        {
            return new DataResult<List<Resume>>(_resumeDal.GetAll(), true);
        }

        public DataResult<Resume> GetResumeById(int id)
        {
            return new DataResult<Resume>(_resumeDal.GetById(id), true);
        }

        public Result UpdateResume(Resume resume)
        {
            _resumeDal.Update(resume);
            return new Result(true);
        }
    }
}
