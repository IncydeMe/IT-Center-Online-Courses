using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();

        public Task CreateRole(Role newRole);
    }
}
