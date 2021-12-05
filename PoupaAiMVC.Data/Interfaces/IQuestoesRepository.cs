using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Interfaces
{
    public interface IQuestoesRepository
    {

        void Create(Questao questoes);
        List<Questao> Read();
        void Update(Questao questoes);
        void Delete(Questao questoes);
        Questao GetByID(int questoesID);
        List<Questao> GetByMundo1();
        List<Questao> GetByMundo2();
        List<Questao> GetByMundo3();

    }
}
