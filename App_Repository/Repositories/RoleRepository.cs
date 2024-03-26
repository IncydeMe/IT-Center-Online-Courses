using App_BusinessObject.Models;
using App_DataAccessObject;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public async Task<List<Role>> GetAllRoles() => await RoleDAO.Instance.GetAllRoles();

        public async Task CreateRole(Role newRole) => await RoleDAO.Instance.CreateRole(newRole);
    }
}
