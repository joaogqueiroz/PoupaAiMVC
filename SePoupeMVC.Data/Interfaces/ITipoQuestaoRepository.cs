using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Interfaces
{
    public interface ITipoQuestaoRepository
    {

        void Create(TipoQuestao tipoQuestao);
        List<TipoQuestao> Read();
        void Update(TipoQuestao tipoQuestao);
        void Delete(TipoQuestao tipoQuestao);
        TipoQuestao GetByID(int tipoQuestaoID);
    }
}
