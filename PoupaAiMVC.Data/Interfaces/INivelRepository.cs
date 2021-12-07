using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Interfaces
{
    public interface INivelRepository
    {
        void Create(Nivel nivel);
        List<Nivel> Read();
        void Update(Nivel nivel);
        void Delete(Nivel nivel);
        Nivel GetByID(int nivelID);
        List<Nivel> GetNivelByIDQuestaoList(int idQuestao);
        Nivel GetNivelByIDQuestaoFrist(int idQuestao);
    }
}
