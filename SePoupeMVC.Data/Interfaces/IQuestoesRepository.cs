using SePoupeMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Interfaces
{
    public interface IQuestoesRepository
    {

        void Create(Questoes questoes);
        List<Questoes> Read();
        void Update(Questoes questoes);
        void Delete(Questoes questoes);
        Questoes GetByID(int questoesID);
    }
}
