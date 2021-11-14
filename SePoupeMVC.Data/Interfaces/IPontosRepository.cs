using SePoupeMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Interfaces
{
   public interface IPontosRepository
    {
        void Create(Pontos pontos);
        List<Pontos> Read();
        void Update(Pontos pontos);
        void Delete(Pontos pontos);
        Pontos GetByID(int pontosID);
        int GetPontosByIDUsuario(int idUsuario);
    }
}
