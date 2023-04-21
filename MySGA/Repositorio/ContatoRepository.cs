using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using MySGA.Data;
using MySGA.Models;
using MySGA.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySGA.Repositorio
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DatabaseContext _dbContext;
        public ContatoRepository(DatabaseContext databaseContext) 
        {
            _dbContext = databaseContext;
        }

        public ContatoModel ListById(int id)
        {
            return _dbContext.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public List<ContatoModel> GetAll()
        {
            return _dbContext.Contatos.ToList();
        }

        public ContatoModel Create(ContatoModel contato)
        {
            _dbContext.Contatos.Add(contato);
            _dbContext.SaveChanges();
            return contato;
        }

        public ContatoModel Update(ContatoModel contato)
        {
            ContatoModel contatoDb = ListById(contato.Id);

            if (contatoDb == null) throw new System.Exception("O contato não existe na base de dados.");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _dbContext.Contatos.Update(contatoDb);
            _dbContext.SaveChanges();
            return contato;
        }

        public bool Delete(int id)
        {
            ContatoModel contatoDb = ListById(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro ao tentar deletar o contato.");
            _dbContext.Contatos.Remove(contatoDb);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
