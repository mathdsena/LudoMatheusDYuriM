using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LudoMatheusDYuriM
{
    internal class Jogador
    {
        private String cor;
        private int identificador;
        private String nome;
        public Peao[] peao = new Peao[4];

        public Jogador(string cor, int identificador, String nome)
        {
            this.cor = cor;
            this.identificador = identificador;
            this.nome = nome;

            for (int i = 0; i < peao.Length; i++)
            {
                this.peao[i] = new Peao(cor, i, -1);
            }
        }

        public Peao[] GetPeao()
        {
            return peao;
        }
        public int GetIdentificador()
        {
            return identificador;
        }
        
        public string GetNome()
        {
            return nome;
        }
        public int VerficarQtdPeao()
        {
            int count = 0;
            foreach (Peao peao in this.peao)
            {
                if (peao.Posicao > -1)
                {
                    count++;
                }
            }
            return count;
        }

        public int VerificarPeaoDisponivel()
        {
            for (int i = 0; i < peao.Length; i++)
            {
                if (peao[i].Posicao == -1)
                {
                    return i;
                }
            }

            return -1;
        }
        public int EscolherPeao(bool peaoNovo)
        {
            int count = VerficarQtdPeao();
            if (peaoNovo) { count++; }
            if (count >= 1)
            {
                Console.WriteLine("Escolha um peão:");
                for (int i = 0; i < peao.Length; i++)
                {
                    if (peao[i].Posicao > -1)
                    {
                        Console.WriteLine($"{i + 1}. para o peão {peao[i].identificador + 1};");
                    }
                }
                if (peaoNovo) { Console.WriteLine("5. para criar um novo peão"); }
                
                int qualPeao = int.Parse(Console.ReadLine());
                if (qualPeao > -1)
                {
                    return (qualPeao - 1);
                }
                return -1;
            }
            else
            {
                for (int i = 0; i < peao.Length; i++)
                {
                    if (peao[i].Posicao > -1)
                    {
                        Console.WriteLine("Só possui o peão " + (i + 1));
                        return i;
                    }
                }
            }
            return -1;
        }

        public string LancarDado()
        {
            bool peaoNovo = false;
            string ganhador;
            int id = -1;
            int dado, count = 1, op = -1;
            do
            {
                Random n = new Random();
                dado = n.Next(1, 7);
                Console.WriteLine("Dado: " + dado);
                if (dado == 6)
                {
                    id = VerificarPeaoDisponivel();
                    if (id == -1)
                    {
                    }
                    else
                    {
                        peaoNovo = true;
                    }
                }
                    op = EscolherPeao(peaoNovo);
                    if (op >= 0 && op < 4)
                    {
                        peao[op].Mover(dado);
                        Console.WriteLine("O peão " + (op + 1) + " chegou a posição " + peao[op].Posicao);
                    }
                    else if (op == 4 && peaoNovo)
                    {
                        Console.WriteLine($"Mais um peão para o jogador {identificador + 1} {nome}");
                        peao[id].Posicao = 0;
                    }
                    else
                    {
                        Console.WriteLine($"O jogador {identificador + 1} não possui peões no jogo");
                    }
                count++;
                peaoNovo = false;
            }
            while (dado == 6 && count < 4);

            if (op > -1)
            {
                if (peao[op].Posicao >= 52)
                {
                    return ganhador = nome;
                }
                else
                {
                    return ganhador = null;
                }
            }

            return null;
        }
    }
}
