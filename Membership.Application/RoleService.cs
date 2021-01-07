using Membership.Data.Entities;
using Membership.Service.interfaces;
using Membership.ViewModel.Common;
using Membership.ViewModel.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Service
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseResult<bool>> Create(RoleCreateRequest request)
        {
            if (await _roleManager.FindByNameAsync(request.Name) != null) 
                return new ResponseErrorResult<bool>("Role name already exist");

            var role = new AppRole()
            {
                Description = request.Description,
                Name = request.Name,
                NormalizedName = request.NormalizedName,
            };

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                return new ResponseErrorResult<bool>(result.Errors.ToString());

            return new ResponseSuccessResult<bool>();
        }

        public async Task<ResponseResult<bool>> Delete(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return new ResponseErrorResult<bool>("Role not exist");

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) return new ResponseErrorResult<bool>(result.Errors.ToString());

            return new ResponseSuccessResult<bool>();
        }

        public async Task<ResponseResult<List<RoleVm>>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                }).ToListAsync();

            return new ResponseSuccessResult<List<RoleVm>>(roles);
        }

        public async Task<ResponseResult<bool>> Update(RoleUpdateRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
                return new ResponseErrorResult<bool>("Role not exist");

            if (await _roleManager.FindByNameAsync(request.Name) != null)
                return new ResponseErrorResult<bool>("Role name already exist");

            role.Description = request.Description;
            role.Name = request.Name;
            role.NormalizedName = request.NormalizedName;

            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded) return new ResponseErrorResult<bool>(result.Errors.ToString());

            return new ResponseSuccessResult<bool>();
        }
    }
}
