using Senai.EfCore.Tarde.Controllers.Contexts;
using Senai.EfCore.Tarde.Domains;
using Senai.EfCore.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Tarde.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura
        /// <summary>
        /// Lista todos os produtos cadastrados 
        /// </summary>
        /// <returns>Retorna uma Lista de Produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="id"> Id do Produto</param>
        /// <returns>Lista de produto</returns>
       
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                //return produto; 
                //Simplificado:
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id);

                return _ctx.Produtos.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produtos pelo
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome == nome).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        #endregion

        #region Gravação

        /// <summary>
        /// Edita um produto 
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Produto produtoTemp = _ctx.Produtos.Find(produto.Id);
                //Qual o problema de usarmos dessa maneira?
                //Se amanhã muda a forma de como eu busco um Id, não será mais somente em um local que terei que alterar. Mas se utilizarmos o método BuscarPorId, amanhã se mudar a forma de encontrar o Id precisarei alterar somente o BuscarPorId e o Editar continuara funcionando.
                
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se p produto existe
                //Caso não existir gera uma exception 
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera suas propriedades 
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera Produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o contexto
                _ctx.SaveChanges();
                        


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo pruduto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona objeto do tipo produto ao dbset do contexto

                _ctx.Produtos.Add(produto);

                //Outras maneiras de se fazer:
                // _ctx.Set<Produto>().Update(produto);
                // _ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                //Salva as alterações no contexto

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto pelo id    
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se p produto existe
                //Caso não existir gera uma exception 
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Remove um produto do DbSet
                _ctx.Produtos.Remove(produtoTemp);
                //Salva as alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion


    }
}
