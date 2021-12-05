using Dapper;
using MySql.Data.MySqlClient;
using PoupaAiMVC.Data.Entities;
using PoupaAiMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Repositories
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
            var query = @"
            INSERT INTO alternativas(                
                alternativa_1,
                alternativa_2,
                alternativa_3,
                alternativa_4,
                alternativa_correta,
                Id_Questao)
            VALUES(
                @alternativa_1,
                @alternativa_2,
                @alternativa_3,
                @alternativa_4,
                @alternativa_correta,
                @Id_Questao)";

            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, alternativa);
            }
        }

        public List<Alternativa> Read()
        {
            var query = @"SELECT * FROM alternativas
                          ORDER BY IdAlternativa";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Alternativa>(query).ToList();
            }
        }

        public void Update(Alternativa alternativa)
        {
            var query = @" 
                UPDATE alternativas SET
                alternativa_1 = @alternativa_1,
                alternativa_2 = @alternativa_2,
                alternativa_3 = @alternativa_3,
                alternativa_4 = @alternativa_4,
                alternativa_correta = @alternativa_correta,
                Id_Questao = @Id_Questao
                WHERE
                    Id_Questao = @Id_Questao";
            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, alternativa);
            }
        }

        public void Delete(Alternativa alternativa)
        {
            var query = @"DELETE FROM alternativas
                          WHERE IdAlternativa = @IdAlternativa";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, alternativa);
            }
        }

        public Alternativa GetByID(int alternativaID)
        {
            var query = @"SELECT * FROM alternativas
                          WHERE IdAlternativa = @alternativaID";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Alternativa>(query, new { alternativaID }).FirstOrDefault();
            }
        }

        public List<Alternativa> GetAlternativaByIDQuestao(int idQuestao)
        {
            var query = @"SELECT * FROM alternativas
                          WHERE Id_Questao = @idQuestao";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Alternativa>(query, new { idQuestao }).ToList();
            }
        }
    }
}
