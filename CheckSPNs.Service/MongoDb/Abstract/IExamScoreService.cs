﻿using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;

namespace CheckSPNs.Service.MongoDb.Abstract
{
    public interface IExamScoreService
    {
        Task<string> ImportCsv(List<ExamScore> examScore);
        Task<string> ImportProvinceCity(List<ProvinceCity> provinceCities);
        Task<ExamScoreDTO> GetExamScoreByIdAsync(string id);
        IQueryable<ExamScore> GetExamScore();
    }
}
