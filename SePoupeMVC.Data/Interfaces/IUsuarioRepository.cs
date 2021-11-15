using SePoupeMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        List<Usuario> Read();
        void Update(Usuario usuario);
        void Update(int IdUsuario, string novaSenha);
        void Delete(Usuario usuario);
        Usuario GetByID(int usuarioID);
        Usuario Get(string Email);
        Usuario Get(string Email, string Senha);
        int GetPontuacao(int IdUsuario);

    }
}
