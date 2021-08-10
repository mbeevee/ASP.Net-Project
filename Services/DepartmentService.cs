using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        //Injeção de dependência sempre adicionar o serviço no Startup no ConfigureServices
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        //Retorna todos os departamentos em ordem alfabética com Linq
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(dep => dep.Name).ToList();
        }
    }
}
