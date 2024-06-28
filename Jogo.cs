using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoMatheusDYuriM
{
    internal class Jogo
    {
        public string ganhador;
        private bool outravez;

        public void ComecarJogo ()
        {
            do
            {
                Tabuleiro tabuleiro = new Tabuleiro ();
                int i = 0;
                do
                {
                    if (i == tabuleiro.casas.GetLength(0))
                    {
                        i = 0;
                    }

                    Console.WriteLine("Turno do jogador " + (i + 1) + " "+ tabuleiro.jogador[i].GetNome());
                    ganhador = tabuleiro.jogador[i].LancarDado();
                    Console.WriteLine();

                    i++;
                }
                while (ganhador == null);

                Console.WriteLine($"Parabéns {ganhador}, você ganhou!");

                Console.WriteLine("Gostaria de jogar novamente:\n S para sim;\n N para não.");
                char op = char.Parse(Console.ReadLine());

                switch (op)
                {
                    case 'S':
                        outravez = true;
                        break;
                    case 'N':
                        outravez = false;
                        break;
                    default:
                        outravez = false;
                        break;
                }
            }
            while (outravez);
        }

        public string GetGanhador ()
        {
            return ganhador;
        }
    }
}
