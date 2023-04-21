using Microsoft.AspNetCore.Mvc;
using MySGA.Models;
using MySGA.Repositorio.Interfaces;
using System.Collections.Generic;

namespace MySGA.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController (IContatoRepository iContatoRepository)
        {
            _contatoRepository = iContatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.GetAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update( int id)
        {
            ContatoModel contato =  _contatoRepository.ListById(id);
            return View(contato);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ContatoModel contato = _contatoRepository.ListById(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool apagado = _contatoRepository.Delete(id);
                    if(apagado)
                    {
                        TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Ops, não conseguimos excluir o contato, tente novamente.";
                    }
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir o contato, tente novamente, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Create(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }         
        }

        [HttpPost]
        public IActionResult Update(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Update(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
