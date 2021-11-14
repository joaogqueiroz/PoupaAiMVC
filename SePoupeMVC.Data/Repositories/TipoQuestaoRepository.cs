using Dapper;
using MySql.Data.MySqlClient;
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
            var query = @"
            INSERT INTO tipo_questao(                
                Descricao,
                Id_Questao)
            VALUES(
                @Descricao,
                @Id_Questao)";

            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, tipoQuestao);
            }
        }

        public List<TipoQuestao> Read()
        {
            var query = @"SELECT * FROM tipo_questao";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<TipoQuestao>(query).ToList();
            }
        }

        public void Update(TipoQuestao tipoQuestao)
        {
            var query = @" 
                UPDATE tipo_questao SET
                Descricao = @Descricao,
                Id_Questao = @Id_Questao
                WHERE
                    IdTipo = @IdTipo";
            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, tipoQuestao);
            }
        }

        public void Delete(TipoQuestao tipoQuestao)
        {
            var query = @"DELETE FROM tipo_questao
                          WHERE IdTipo = @IdTipo";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, tipoQuestao);
            }
        }

        public TipoQuestao GetByID(int tipoQuestaoID)
        {
            var query = @"SELECT * FROM tipo_questao
                          WHERE IdTipo = @tipoQuestaoID";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<TipoQuestao>(query, new { tipoQuestaoID }).FirstOrDefault();
            }
        }

    }
}
