using AutoMapper;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Handlers
{
    public class PhoneNumberCommandHandler : IRequestHandler<ReportPhoneNumberCommand, Result>,
        IRequestHandler<AddPhoneNumberTypeOfReportCommand, Result>,
        IRequestHandler<AddOverallReportPhoneNumberCommand, Result>,
        IRequestHandler<DeletePhoneNumberCommand, Result>,
        IRequestHandler<EditPhoneNumberCommand, Result>
    {

        private readonly IPhoneNumberService _phoneNumberService;
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public PhoneNumberCommandHandler(IPhoneNumberService phoneNumberService, IMapper mapper, IReportService reportService)
        {
            _phoneNumberService = phoneNumberService;
            _mapper = mapper;
            _reportService = reportService;
        }

        #region Commented Code
        //public async Task<Response<string>> Handle(AddPhoneNumberCommand request, CancellationToken cancellationToken)
        //{
        //    var phoneNumber = _mapper.Map<Number.PhoneNumbers>(request);

        //    var exitPhoneNumber = await _phoneNumberService.GetInfoByPhoneNumber(phoneNumber.PhoneNumber);

        //    var result = "";

        //    if (exitPhoneNumber == null)
        //    {
        //        result = await _phoneNumberService.AddAsync(phoneNumber, request.TypeOfReportsId);
        //    }
        //    else
        //    {
        //        result = await _phoneNumberService.AddNewReport(phoneNumber.PhoneNumber, request.TypeOfReportsId);
        //    }

        //    await _reportService.AddReport(request.Comment, phoneNumber.PhoneNumber);

        //    if (result == "Phone Number added successfully")
        //    {
        //        return Created(result);
        //    }
        //    else return BadRequest<string>(result);
        //}
        #endregion

        public async Task<Result> Handle(ReportPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var exitPhoneNumber = await _phoneNumberService.GetInfoByPhoneNumber(request.PhoneNumber);
            if (exitPhoneNumber == null)
            {
                await _phoneNumberService.AddAsync(request.PhoneNumber);
            }
            return Result.Success();
        }

        public async Task<Result> Handle(AddOverallReportPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            await _phoneNumberService.UpdateOverallReport(request.reportEnum, request.PhoneNumber);
            return Result.Success();
        }

        public async Task<Result> Handle(AddPhoneNumberTypeOfReportCommand request, CancellationToken cancellationToken)
        {
            await _phoneNumberService.AddTypeReport(request.PhoneNumber, request.TypeOfReportsId);
            return Result.Success();
        }

        public async Task<Result> Handle(EditPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var phoneNumbers = _phoneNumberService.GetPhoneNumberByIdAsync(request.Id).Result;
            if (phoneNumbers == null)
            {
                return Result.Failure(Error.NullValue);
            }
            var phoneNumberMapper = _mapper.Map(request, phoneNumbers);

            await _phoneNumberService.EditAsync(phoneNumberMapper);

            return Result.Success();
        }

        public async Task<Result> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = await _phoneNumberService.GetPhoneNumberByIdAsync(request.Id);
            if (phoneNumber == null)
            {
                return Result.Failure(Error.NullValue);
            }
            await _phoneNumberService.DeleteAsync(phoneNumbers: phoneNumber);

            return Result.Success();
        }
    }
}
