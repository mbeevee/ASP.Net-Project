using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        //Injeção de dependência sempre adicionar o serviço no Startup no ConfigureServices
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        // Retorna todos os vendedores que tem no Banco de dados
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        //Insere um novo vendedor no banco de dados
        //Obs: No final de uma inserção ou remoção sempre dar SaveChanges no context
        public void Insert(Seller sl)
        {
            _context.Add(sl);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
