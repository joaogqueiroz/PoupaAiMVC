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
    public class PontosRepository : IPontosRepository
    {

        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public PontosRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(Pontos pontos)
        {
            var query = @"
            INSERT INTO pontos(                
                Nivel1,
                Nivel2,
                Nivel3,
                IdUsuario)
            VALUES(
                @Nivel1,
                @Nivel2,
                @Nivel3,
                @IdUsuario)";

            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public List<Pontos> Read()
        {
            var query = @"SELECT * FROM pontos";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<Pontos>(query).ToList();
            }
        }


        public void Update(Pontos pontos)
        {
            var query = @" 
                UPDATE pontos SET
                    Nivel1 = @Nivel1,
                    Nivel2 = @Nivel2,
                    Nivel3 = @Nivel3                  
                WHERE
                    IdPontos = @IdPontos";
            using (var connetionString = new MySqlConnection(_context_QuestoesDB))
            {
                connetionString.Execute(query, pontos);
            }
        }

        public void Delete(Pontos pontos)
        {
            var query = @"DELETE FROM pontos
                          WHERE IdPontos = @IdPontos";
            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                connection.Execute(query, pontos);
            }
        }

        public Pontos GetByID(int pontosID)
        {
            var query = @"SELECT * FROM pontos
                          WHERE Pontos = @Pontos";

            using (var connection = new MySqlConnection(_context_QuestoesDB))
            {
                return connection.Query<Pontos>(query, new { pontosID }).FirstOrDefault();
            }
        }
        public int? GetPontosByIDUsuario(int idUsuario)
        {
            var query = @"SELECT SUM(Nivel1 + Nivel2 + Nivel3) AS PontuacaoTotal 
                        FROM pontos WHERE(Id_Usuario = @idUsuario)";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<int?>(query, new { idUsuario }).FirstOrDefault();
            }
        }
    }
}
