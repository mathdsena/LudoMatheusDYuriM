using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoMatheusDYuriM
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            Jogo jogo = new Jogo();
            jogo.ComecarJogo();
            Console.WriteLine("Obrigado por jogar!");
            Console.ReadLine();
        }
    }
}
