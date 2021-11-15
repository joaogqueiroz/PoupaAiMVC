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

        public void Create(Questao questoes)
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

        public List<Questao> Read()
        {
            var query = @"SELECT * FROM questoes";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Questao>(query).ToList();
            }
        }

        public void Update(Questao questoes)
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

        public void Delete(Questao questoes)
        {
            var query = @"DELETE FROM questoes
                          WHERE IdQuestao = @IdQuestao";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, questoes);
            }
        }

        public Questao GetByID(int questoesID)
        {
            var query = @"SELECT * FROM questoes
                          WHERE IdQuestao = @questoesID";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Questao>(query, new { questoesID }).FirstOrDefault();
            }
        }

        public List<Questao> GetByMundo1()
        {
            var query = @"SELECT Q.IdQuestao, Q.Enunciado, N.IdNivel, N.Descricao
                        FROM questoes Q INNER JOIN
                        nivel N ON Q.IdQuestao = N.Id_Questao
                        WHERE (N.Descricao = 'Nivel1');";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Questao>(query).ToList();
            }
        }

        public List<Questao> GetByMundo2()
        {
            throw new NotImplementedException();
        }

        public List<Questao> GetByMundo3()
        {
            throw new NotImplementedException();
        }
    }
}
