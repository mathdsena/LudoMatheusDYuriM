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
        private int[] CSeguras = { 0, 5, 13, 18, 26, 31, 39, 44, 47, 48, 49, 50, 51, 52 };

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
                    break;
                case 1:
                    cor = "azul";
                    break;
                case 2:
                    cor = "verde";
                    break;
                case 3:
                    cor = "amarelo";
                    break;
            }

            jogador[id] = new Jogador(cor, id, nome);
        }

        public void VerificarCaptura(int idJ, int idP)
        {

                for (int i = 0; i < 4; i++)
                {
                    if (i != idJ)
                    {
                        foreach (Peao peao in jogador[i].GetPeao())
                        {
                            if (jogador[idJ].peao[idP].Posicao == peao.Posicao)
                            {
                                if (VerificarCasaSegura(peao.Posicao))
                                {

                                }
                                else
                                {
                                    peao.RetornarCasa();
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
