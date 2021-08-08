using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        //Injeção de dependência do DBContext
        private readonly SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        //Método para popular o banco de dados
        public void Seed()
        {
            //Testando se o BD possui dados
            if (_context.Department.Any() || _context.Department.Any() || _context.SalesRecord.Any())
            {
                return;
            }
                Department d1 = new Department(1, "Fashion");
                Department d2 = new Department(2, "Electronics");
                Department d3 = new Department(3, "Books");

                Seller s1 = new Seller(1, "Kevin Thauan", "kevinmlkzika@gmail.com", new DateTime(2002, 10, 23), 3234.39, d2);
                Seller s2 = new Seller(2, "João Maia", "maiamlkzika@gmail.com", new DateTime(1999, 12, 24), 3489.28, d2);
                Seller s3 = new Seller(3, "Eduardo Lyra", "lyramlkzika@gmail.com", new DateTime(1999, 09, 10), 1394.38, d1);

                SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 07, 02), 129.92, SaleStatus.Billed, s1) ;
                SalesRecord sr2 = new SalesRecord(2, new DateTime(2021, 01, 25), 2176.93, SaleStatus.Canceled, s3);
                SalesRecord sr3 = new SalesRecord(3, new DateTime(2021, 08, 07), 7354.12, SaleStatus.Pending, s3);

                //Adicionando os dados ao DBContext
                _context.Department.AddRange(d1, d2, d3);

                _context.Seller.AddRange(s1, s2, s3);

                _context.SalesRecord.AddRange(sr1, sr2, sr3);

                //Salva os dados no DBContext
                _context.SaveChanges();
            
        }
    }
}
