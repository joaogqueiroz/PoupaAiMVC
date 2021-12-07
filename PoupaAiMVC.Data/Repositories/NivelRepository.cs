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
            var query = @"
            INSERT INTO nivel(                
                nivel_1,
                nivel_2,
                nivel_3,
                nivel_4,
                nivel_correta,
                Id_Questao)
            VALUES(
                @nivel_1,
                @nivel_2,
                @nivel_3,
                @nivel_4,
                @nivel_correta,
                @Id_Questao)";

            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, nivel);
            }
        }

        public List<Nivel> Read()
        {
            var query = @"SELECT * FROM nivel
                          ORDER BY IdNivel";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Nivel>(query).ToList();
            }
        }

        public void Update(Nivel nivel)
        {
            var query = @" 
                UPDATE nivel SET
                nivel_1 = @nivel_1,
                nivel_2 = @nivel_2,
                nivel_3 = @nivel_3,
                nivel_4 = @nivel_4,
                nivel_correta = @nivel_correta,
                Id_Questao = @Id_Questao
                WHERE
                    Id_Questao = @Id_Questao";
            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, nivel);
            }
        }

        public void Delete(Nivel nivel)
        {
            var query = @"DELETE FROM nivel
                          WHERE IdNivel = @IdNivel";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, nivel);
            }
        }

        public Nivel GetByID(int nivelID)
        {
            var query = @"SELECT * FROM nivel
                          WHERE IdNivel = @nivelID";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Nivel>(query, new { nivelID }).FirstOrDefault();
            }
        }

        public List<Nivel> GetNivelByIDQuestaoList(int idQuestao)
        {
            var query = @"SELECT * FROM nivel
                          WHERE Id_Questao = @idQuestao";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Nivel>(query, new { idQuestao }).ToList();
            }
        }
        public Nivel GetNivelByIDQuestaoFrist(int idQuestao)
        {
            var query = @"SELECT * FROM nivel
                          WHERE Id_Questao = @idQuestao";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Nivel>(query, new { idQuestao }).FirstOrDefault();
            }
        }
    }
}
