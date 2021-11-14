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
            var query = @"
            INSERT INTO questoes(                
                Enunciado,
                Imagem)
            VALUES(
                @Enunciado,
                @Imagem)";

            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, questoes);
            }
        }

        public List<Questoes> Read()
        {
            var query = @"SELECT * FROM questoes";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Questoes>(query).ToList();
            }
        }

        public void Update(Questoes questoes)
        {
            var query = @"
                UPDATE questoes SET
                Enunciado = @Enunciado,
                Imagem = @Imagem
                WHERE
                    IdQuestao = @IdQuestao";
            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, questoes);
            }
        }

        public void Delete(Questoes questoes)
        {
            var query = @"DELETE FROM questoes
                          WHERE IdQuestao = @IdQuestao";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, questoes);
            }
        }

        public Questoes GetByID(int questoesID)
        {
            var query = @"SELECT * FROM questoes
                          WHERE IdQuestao = @questoesID";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Questoes>(query, new { questoesID }).FirstOrDefault();
            }
        }
    }
}
