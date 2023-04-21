using MySGA.Models;
using System.Collections.Generic;

namespace MySGA.Repositorio.Interfaces
{
    public interface IContatoRepository
    {
        ContatoModel ListById(int id);
        List<ContatoModel> GetAll();
        ContatoModel Create(ContatoModel contato);
        ContatoModel Update(ContatoModel contato);
        bool Delete(int id);
    }
}
