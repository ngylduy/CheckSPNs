using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.DTO.Requests;
using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Domain.Helpers;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static CheckSPNs.Domain.Exceptions.AppUserException;

namespace CheckSPNs.Service.EF.Implementations;

public class AuthorizationService : IAuthorizationService
{
    private readonly RoleManager<AppRoles> _roleManager;
    private readonly UserManager<AppUsers> _userManager;
    private readonly CheckSPNsContext _context;

    public AuthorizationService(RoleManager<AppRoles> roleManager,
                                    UserManager<AppUsers> userManager,
                                    CheckSPNsContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task AddRoleAsync(string roleName)
    {
        var identityRole = new AppRoles();
        identityRole.Name = roleName;
        await _roleManager.CreateAsync(identityRole);
    }

    public async Task<bool> IsRoleExistByName(string roleName)
    {
        //var role=await _roleManager.FindByNameAsync(roleName);
        //if(role == null) return false;
        //return true;
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task EditRoleAsync(EditRoleRequest request)
    {
        //check role is exist or not
        var role = await _roleManager.FindByIdAsync(request.Id.ToString());
        if (role is null)
        {
            throw new DataException("Role not found");
        }
        role.Name = request.Name;
        await _roleManager.UpdateAsync(role);
    }

    public async Task DeleteRoleAsync(Guid roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
        {
            throw new DataException("Role not found");
        }
        var users = await _userManager.GetUsersInRoleAsync(role.Name);
        if (users is not null && users.Count() > 0)
        {
            throw new DataException("Role has users");
        }
        await _roleManager.DeleteAsync(role);
    }

    public async Task<bool> IsRoleExistById(Guid roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role == null) return false;
        else return true;
    }

    public async Task<List<AppRoles>> GetRolesList()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<AppRoles> GetRoleById(Guid id)
    {
        return await _roleManager.FindByIdAsync(id.ToString());
    }

    public async Task<ManageUserRolesResult> ManageUserRolesData(AppUsers user)
    {
        var response = new ManageUserRolesResult();
        var rolesList = new List<UserRoles>();
        //Roles
        var roles = await _roleManager.Roles.ToListAsync();
        response.UserId = user.Id;
        foreach (var role in roles)
        {
            var userrole = new UserRoles();
            userrole.Id = role.Id;
            userrole.Name = role.Name;
            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                rolesList.Add(userrole);
            }
        }
        response.userRoles = rolesList;
        return response;
    }

    public async Task UpdateUserRoles(UpdateUserRolesRequest request)
    {
        var transact = await _context.Database.BeginTransactionAsync();
        try
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);

            var selectedRoles = request.userRoles.Select(x => x.Name);

            var addRolesresult = await _userManager.AddToRolesAsync(user, selectedRoles);

            await transact.CommitAsync();
        }
        catch (Exception ex)
        {
            await transact.RollbackAsync();
        }
    }

    public async Task<ManageUserClaimsResult> ManageUserClaimData(AppUsers user)
    {
        var response = new ManageUserClaimsResult();
        var usercliamsList = new List<UserClaims>();
        response.UserId = user.Id;
        //Get USer Claims
        var userClaims = await _userManager.GetClaimsAsync(user); //edit
                                                                  //create edit get print
        foreach (var claim in ClaimsStore.claims)
        {
            var userclaim = new UserClaims();
            userclaim.Type = claim.Type;
            if (userClaims.Any(x => x.Type == claim.Type))
            {
                userclaim.Value = true;
            }
            else
            {
                userclaim.Value = false;
            }
            usercliamsList.Add(userclaim);
        }
        response.userClaims = usercliamsList;
        //return Result
        return response;
    }

    public async Task UpdateUserClaims(UpdateUserClaimsRequest request)
    {
        var transact = await _context.Database.BeginTransactionAsync();
        try
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }
            //remove old Claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            if (userClaims.Count > 0)
            {
                await _userManager.RemoveClaimsAsync(user, userClaims);
            }

            var claims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

            await _userManager.AddClaimsAsync(user, claims);
            await transact.CommitAsync();
        }
        catch (Exception ex)
        {
            await transact.RollbackAsync();
        }
    }
}
