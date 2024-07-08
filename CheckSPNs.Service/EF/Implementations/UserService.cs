using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static CheckSPNs.Domain.Exceptions.AppUserException;

namespace CheckSPNs.Service.EF.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IDistributedCacheService _distributedCacheService;

        private readonly CheckSPNsContext _checkSPNsContext;
        private readonly IUrlHelper _urlHelper;
        private readonly IEmailsService _emailsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(
            UserManager<AppUsers> userManager,
            IDistributedCacheService distributedCacheService,
            CheckSPNsContext checkSPNsContext,
            IUrlHelper urlHelper,
            IHttpContextAccessor httpContextAccessor,
            IEmailsService emailsService)
        {
            _userManager = userManager;
            _distributedCacheService = distributedCacheService;
            _checkSPNsContext = checkSPNsContext;
            _urlHelper = urlHelper;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
        }

        public async Task AddUserAsync(AppUsers user, string password, CancellationToken cancellationToken)
        {
            var trans = await _checkSPNsContext.Database.BeginTransactionAsync();
            try
            {
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                if (existUser != null) throw new UserAlreadyExistsException($"email {existUser.Email}");

                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                if (userByUserName != null) throw new UserAlreadyExistsException($"username {existUser.UserName}");

                user.DateCreated = DateTime.Now;

                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded) throw new Exception("Cannot create new user!");

                await _userManager.AddToRoleAsync(user, "User");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var url = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentications", new { userId = user.Id, code = code });

                await _emailsService.SendEmailAsync(cancellationToken, new Domain.EmailRequest
                {
                    To = user.Email,
                    Subject = "Confirm Email",
                    Content = $"To Confirm Email Click Link: <a href='{url}'>Link Of Confirmation</a>"
                });

                await trans.CommitAsync();

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
