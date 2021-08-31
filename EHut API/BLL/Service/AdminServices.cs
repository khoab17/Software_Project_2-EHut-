using BEL.Model;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AdminServices
    {
        AdminRepo adminRepo = new AdminRepo();
        public List<AdminModel> GetAll()
        {
            var temp = adminRepo.GetAll();
            var data = AutoMapper.Mapper.Map<List<Admin>, List<AdminModel>>(temp);
            return data;
        }
    }
}
