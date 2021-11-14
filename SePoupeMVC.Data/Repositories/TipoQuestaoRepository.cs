using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Repositories
{
    public class TipoQuestaoRepository : ITipoQuestaoRepository
    {

        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public TipoQuestaoRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(TipoQuestao tipoQuestao)
        {
            throw new NotImplementedException();
        }

        public List<TipoQuestao> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(TipoQuestao tipoQuestao)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoQuestao tipoQuestao)
        {
            throw new NotImplementedException();
        }

        public TipoQuestao GetByID(int tipoQuestaoID)
        {
            throw new NotImplementedException();
        }
    }
}
