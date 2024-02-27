using App_BusinessObject.Models;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();

        public void CreateRole(Role newRole);
    }

    public class RoleRepository : IRoleRepository
    {
        public async Task<List<Role>> GetAllRoles() => await RoleDAO.Instance.GetAllRoles();

        public async void CreateRole(Role newRole) => RoleDAO.Instance.CreateRole(newRole);
    }
}
