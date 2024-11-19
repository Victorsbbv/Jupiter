using System.Collections.Generic;
using System.Threading;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();

    public static void Main()
    {
        string senha = "";
        bool produtos = false;
        while (true)
        {

            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.WriteLine("INFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar Produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                int decisao = Convert.ToInt32(Console.ReadLine());

                // OPÇÃO 1 --- VENDER PRODUTOS
                switch (decisao)
                {
                    case 1:
                        {
                            Console.WriteLine("----------LISTA DE PRODUTOS----------");
                            foreach (var item in listaProdutos)
                            {
                                Console.WriteLine();
                                Console.Write("ID do Produto: ");
                                Console.Write(item.Id);
                                Console.WriteLine();
                                Console.Write("Nome do Produto: ");
                                Console.Write(item.Nome);
                                Console.WriteLine();
                                Console.Write("Quantidade do Produto: ");
                                Console.Write(item.Quantidade);
                                Console.WriteLine();
                            }
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("Escolha o seu produto: ");
                            int Id = Convert.ToInt32(Console.ReadLine());
                            var produto_unico = listaProdutos.Find(x => x.Id == Id);
                            if (produto_unico != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"Produto encontrado: {produto_unico.Nome} - Quantidade: {produto_unico.Quantidade}");
                                Thread.Sleep(1000);
                                Console.WriteLine("Quantos itens deseja vender?");
                                int quantidadeVenda = Convert.ToInt32(Console.ReadLine());

                                if (quantidadeVenda <= produto_unico.Quantidade)
                                {
                                    produto_unico.Quantidade -= quantidadeVenda;
                                    Console.Clear();
                                    Console.WriteLine($"Venda realizada! Quantidade restante de {produto_unico.Nome}: {produto_unico.Quantidade}");
                                    Thread.Sleep(3000);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Quantidade insuficiente em estoque.");
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Produto não encontrado.");
                                Thread.Sleep(1000);
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("----------LISTA DE PRODUTOS----------");
                            foreach (var item in listaProdutos)
                            {
                                Console.WriteLine();
                                Console.Write("ID do Produto: ");
                                Console.Write(item.Id);
                                Console.WriteLine();
                                Console.Write("Nome do Produto: ");
                                Console.Write(item.Nome);
                                Console.WriteLine();
                                Console.Write("Quantidade do Produto: ");
                                Console.Write(item.Quantidade);
                                Console.WriteLine();
                            }
                            Console.WriteLine("-------------------------------------");
                            Thread.Sleep(7000);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Digite a senha atual:");
                            string senhaAtual = Console.ReadLine();
                            if (senhaAtual == senha)
                            {
                                Console.WriteLine("Digite a nova senha:");
                                senha = Console.ReadLine();
                                Console.WriteLine("Senha alterada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Senha incorreta.");
                            }
                            Thread.Sleep(1000);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Digite a senha atual para fechar o caixa:");
                            string senhaAtual = Console.ReadLine();
                            if (senhaAtual == senha)
                            {
                                Console.WriteLine("----------LISTA DE PRODUTOS----------");
                                foreach (var item in listaProdutos)
                                {
                                    Console.WriteLine();
                                    Console.Write("ID do Produto: ");
                                    Console.Write(item.Id);
                                    Console.WriteLine();
                                    Console.Write("Nome do Produto: ");
                                    Console.Write(item.Nome);
                                    Console.WriteLine();
                                    Console.Write("Quantidade do Produto: ");
                                    Console.Write(item.Quantidade);
                                    Console.WriteLine();
                                }
                                Console.WriteLine("-------------------------------------");
                                Console.WriteLine("Caixa será fechado em 20 segundos...");
                                Thread.Sleep(20000);
                                Console.Clear();
                                Console.WriteLine("----------PROGRAMA ENCERRADO----------");
                                Thread.Sleep(2000);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Senha incorreta.");
                                Thread.Sleep(1000);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção inválida!!!");
                            Thread.Sleep(1000);
                            break;
                        }

                }

                //-------------------

                //1 - COLOCAR O ID DO PRODUTO E DIMINUIR A QUANTIDADE, SE O ID NÃO EXISTE, MOSTRAR UMA MENSAGEM DE ERRO
                //2 - LISTAR OS PRODUTOS COM A QUANTIDADE ATUALIZADA
                //3 - ALTERAR A SENHA, PARA ALTERAR DEVE PEDIR A SENHA ANTIGA, SE ESTIVER INCORRETO DAR UM AVISO
                //4 - PARA FECHAR O CAIXA DEVE SER INSERIDO A SENHA ATUAL, MOSTRAR A LISTA DE PRODUTOS
                // COM A QUANTIDADE ATUALZIADA E DEPOIS DE 20 SEGUNDOS FINALIZAR O PROGRAMA
            }

        }
    }

    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }
    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }
}
class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}
