using App_BusinessObject.Models;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllRoles();
        public void CreateRole(Role newRole);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository = null;

        public RoleService()
        {
            if (_roleRepository == null)
                _roleRepository = new RoleRepository();
        }

        public async Task<List<Role>> GetAllRoles() => await _roleRepository.GetAllRoles();

        public async void CreateRole(Role newRole) => _roleRepository.CreateRole(newRole);
    }
}
