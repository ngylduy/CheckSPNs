﻿using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using SchoolProject.Data.Entities.Identity;

namespace CheckSPNs.Data.EF.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        CheckSPNsContext _context;

        Repository<ExamScore> _repositoryExamScore;
        Repository<ProvinceCity> _repositoryProvinceCity;
        Repository<UserRefreshToken> _repositoryUserRefreshToken;
        TypeOfReportRepository _typeOfReportRepository;
        PhoneNumberRepository _phoneNumberRepository;
        ReportRepository _reportRepository;
        PhoneNumberTypeOfReportRepository _phoneNumberTypeOfReportRepository;


        private bool disposedValue;

        public UnitOfWork(CheckSPNsContext context)
        {
            _context = context;
        }

        public Repository<ExamScore> RepositoryExamScore
        {
            get
            {
                if (_repositoryExamScore == null)
                {
                    _repositoryExamScore = new Repository<ExamScore>(_context);
                }
                return _repositoryExamScore;
            }
        }

        public Repository<ProvinceCity> RepositoryProvinceCity
        {
            get
            {
                if (_repositoryProvinceCity == null)
                {
                    _repositoryProvinceCity = new Repository<ProvinceCity>(_context);
                }
                return _repositoryProvinceCity;
            }
        }

        public TypeOfReportRepository TypeOfReportRepository
        {
            get
            {
                if (_typeOfReportRepository == null)
                {
                    _typeOfReportRepository = new TypeOfReportRepository(_context);
                }
                return _typeOfReportRepository;
            }
        }

        public PhoneNumberRepository PhoneNumberRepository
        {
            get
            {
                if (_phoneNumberRepository == null)
                {
                    _phoneNumberRepository = new PhoneNumberRepository(_context);
                }
                return _phoneNumberRepository;
            }
        }

        public ReportRepository ReportRepository
        {
            get
            {
                if (_reportRepository == null)
                {
                    _reportRepository = new ReportRepository(_context);
                }
                return _reportRepository;
            }
        }

        public PhoneNumberTypeOfReportRepository PhoneNumberTypeOfReportRepository
        {
            get
            {
                if (_phoneNumberTypeOfReportRepository == null)
                {
                    _phoneNumberTypeOfReportRepository = new PhoneNumberTypeOfReportRepository(_context);
                }
                return _phoneNumberTypeOfReportRepository;
            }
        }

        public Repository<UserRefreshToken> RepositoryUserRefreshToken
        {
            get
            {
                if (_repositoryUserRefreshToken == null)
                {
                    _repositoryUserRefreshToken = new Repository<UserRefreshToken>(_context);
                }
                return _repositoryUserRefreshToken;
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
