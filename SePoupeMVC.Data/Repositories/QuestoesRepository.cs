using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Repositories
{
    public class QuestoesRepository : IQuestoesRepository
    {

        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public QuestoesRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(Questoes questoes)
        {
            throw new NotImplementedException();
        }

        public List<Questoes> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Questoes questoes)
        {
            throw new NotImplementedException();
        }

        public void Delete(Questoes questoes)
        {
            throw new NotImplementedException();
        }

        public Questoes GetByID(int questoesID)
        {
            throw new NotImplementedException();
        }

        public int GetQuestoesByIDUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
