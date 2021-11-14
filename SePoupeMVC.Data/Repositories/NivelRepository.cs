using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Repositories
{
    public class NivelRepository : INivelRepository
    {

        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public NivelRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(Nivel nivel)
        {
            throw new NotImplementedException();
        }

        public List<Nivel> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Nivel nivel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Nivel nivel)
        {
            throw new NotImplementedException();
        }

        public Nivel GetByID(int nivelID)
        {
            throw new NotImplementedException();
        }

        public int GetNivelByIDUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
