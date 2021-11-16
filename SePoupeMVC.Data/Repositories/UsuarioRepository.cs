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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _context_UsuarioDB;
        private readonly string _context_QuestoesDB;

        public UsuarioRepository(string context_UsuarioDB, string context_QuestoesDB)
        {
            _context_UsuarioDB = context_UsuarioDB;
            _context_QuestoesDB = context_QuestoesDB;
        }

        public void Create(Usuario usuario)
        {
            var query = @"
            INSERT INTO Usuario(                
                Nome,
                Senha,
                CPF,
                Email,
                Sexo,
                Tipo,
                Nascimento)
            VALUES(
                @Nome,
                @Senha,
                @CPF,
                @Email,
                @Sexo,
                @Tipo,
                @Nascimento)";

            using (var connetionString = new MySqlConnection(_context_UsuarioDB))
            {
                connetionString.Execute(query, usuario);
            }
        }
        public List<Usuario> Read()
        {
            var query = @"SELECT * FROM Usuario
                          ORDER BY nome";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public void Update(Usuario usuario)
        {
            ////Senha = MD5(@Senha),
            var query = @" 
                UPDATE Usuario SET
                    Nome = @Nome,                    
                    Senha = @Senha,
                    CPF = @CPF,
                    Sexo = @Sexo,
                    Tipo = @Tipo,
                    Nascimento = @Nascimento
                WHERE
                    IdUsuario = @IdUsuario";
            using (var connetionString = new MySqlConnection(_context_UsuarioDB))
            {
                connetionString.Execute(query, usuario);
            }

        }
        public void Update(int IdUsuario, string novaSenha)
        {
            //Senha = CONVERT(VARCHAR(32), HASHBYTES('MD5', @novaSenha), 2)
            var query = @"UPDATE Usuario
                          SET         
                             Senha = @novaSenha
                          WHERE
                               IdUsuario = @IdUsuario";
            using (var connetionString = new MySqlConnection(_context_UsuarioDB))
            {
                connetionString.Execute(query, new { IdUsuario, novaSenha });
            }
        }

        public void Delete(Usuario usuario)
        {
            var query = @"DELETE FROM Usuario
                          WHERE IdUsuario = @IdUsuario";
            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                connection.Execute(query, usuario);
            }
        }

        public Usuario GetByID(int usuarioID)
        {
            var query = @"SELECT * FROM Usuario
                          WHERE usuarioID = @usuarioID";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<Usuario>(query, new { usuarioID }).FirstOrDefault();
            }
        }
        public Usuario Get(string email)
        {
            var query = @"SELECT * FROM Usuario
                          WHERE Email = @email";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<Usuario>(query, new { email }).FirstOrDefault();
            }
        }
        public Usuario Get(string email, string senha)
        {
            var query = @"SELECT IdUsuario FROM Usuario
                          WHERE Email = @email AND Senha = @senha ";

            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<Usuario>(query, new { email, senha }).FirstOrDefault();
            }
        }
        public int GetPontuacao(int IdUsuario)
        {
            var query = @"SELECT IdPontos, Id_Usuario, SUM(Nivel1 + Nivel2 + Nivel3) AS PontuacaoTotal
                          FROM pontos
                          WHERE (Id_Usuario = @IdUsuario)";
            using (var connection = new MySqlConnection(_context_UsuarioDB))
            {
                return connection.Query<int>(query, new { IdUsuario }).FirstOrDefault();
            }
        }
    }
}
