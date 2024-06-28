using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoMatheusDYuriM
{
    internal class Tabuleiro
    {
        public int[,] casas;
        public Jogador[] jogador = new Jogador[4];
        private int[] CSeguras = { 0, 5, 13, 18, 26, 31, 39, 43, 44, 47, 48, 49, 50, 51 };

        public Tabuleiro()
        {
            int op;
            do
            {
                Console.WriteLine("Insira o número de jogadores:\n2 para uma dupla;\n3 para um trio;\n4 para um quarteto;");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 2:
                        casas = new int[2, 52];
                        CriarJogador(0);
                        CriarJogador(1);
                        break;
                    case 3:
                        casas = new int[3, 52];
                        CriarJogador(0);
                        CriarJogador(1);
                        CriarJogador(2);
                        break;
                    case 4:
                        casas = new int[4, 52];
                        CriarJogador(0);
                        CriarJogador(1);
                        CriarJogador(2);
                        CriarJogador(3);
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
            while (op != 2 && op != 4 && op !=3);
        }

        public void CriarJogador(int id)
        {
            Console.Write($"Insira um nome para o jogador {id + 1}: ");
            String nome = Console.ReadLine();
            String cor = "vermelho";

            switch (id)
            {
                case 0:
                    cor = "vermelho";
                    int[] casasVermelho = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51};
                    foreach (int c in casasVermelho)
                    {
                        int i = 0;
                        casas[id, i] = c;
                    }
                    break;
                case 1:
                    cor = "azul";
                    int[] casasAzul = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                    foreach (int c in casasAzul)
                    {
                        int i = 0;
                        casas[id, i] = c;
                    }
                    break;
                case 2:
                    cor = "verde";
                    int[] casasVerde = {26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
                    foreach (int c in casasVerde)
                    {
                        int i = 0;
                        casas[id, i] = c;
                    }
                    break;
                case 3:
                    cor = "amarelo";
                    int[] casasAmarelo = {39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };
                    foreach (int c in casasAmarelo)
                    {
                        int i = 0;
                        casas[id, i] = c;
                    }
                    break;
            }

            jogador[id] = new Jogador(cor, id, nome);
        }

        public void VerificarCaptura(int idJ, int idP)
        {

                for (int i = 0; i < casas.GetLength(0); i++)
                {
                    if (i != idJ)
                    {
                        foreach (Peao peao in jogador[i].GetPeao())
                        {
                        if (idJ < jogador.Length && idP < 4)
                        {
                            if (peao.Posicao > -1 && idJ < casas.GetLength(0) && peao.Posicao < casas.GetLength(1) && jogador[idJ].peao[idP].Posicao > -1)
                            {
                                if (casas[idJ, jogador[idJ].peao[idP].Posicao] == casas[i, peao.Posicao])
                                {
                                    if (VerificarCasaSegura(peao.Posicao))
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine($"O peão {peao.identificador + 1} do jogador {jogador[i].nome} foi capturado");
                                        peao.RetornarCasa();
                                    }
                                }
                            }
                        }
                        }
                    }
                }
        }

        public bool VerificarCasaSegura(int posicao)
        {

                foreach (int segura in CSeguras)
                { 
                    if (segura == posicao)
                    {
                        return true;
                    }
                }
                return false;

        }
    }
}
