using System;
using ArquivoProduto.Entidades;
using System.IO;
using System.Globalization;
namespace exProduto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o caminho do Arquivo: ");

            string path = Console.ReadLine();
            List<Produto> produtos = new List<Produto>();

            using (StreamReader arquivoproduto = File.OpenText(path))
            {
                while (!arquivoproduto.EndOfStream)
                {
                    string[] campos = arquivoproduto.ReadLine().Split(',');
                    string nome = campos[0];
                    double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);

                    produtos.Add(new Produto(nome, preco));
                }
            }

            var media = produtos.Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Medía de Preços = " + media.ToString("F2", CultureInfo.InvariantCulture));

            var nomes = produtos.Where(p => p.Preco < media).OrderByDescending(p => p.Nome).Select(p => p.Nome);

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }




        }
    }
}