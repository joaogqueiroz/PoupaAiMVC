using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Repositories
{
    public class AlternativaRepository : IAlternativaRepository
    {

        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public AlternativaRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }

        public List<Alternativa> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }

        public void Delete(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }

        public Alternativa GetByID(int alternativaID)
        {
            throw new NotImplementedException();
        }

        public int GetAlternativaByIDUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
