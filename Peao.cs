using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoMatheusDYuriM
{
    internal class Peao
    {
        private String cor;
        public int identificador;
        private int posicao;

        public Peao(string cor, int identificador, int posicao)
        {
            this.cor = cor;
            this.identificador = identificador;
            this.posicao = posicao;
        }

        public void Mover(int dado)
        {
            posicao += dado;
        }

        public void RetornarCasa()
        {
            posicao = -1;
        }

        public int Posicao
        {
            get
            {
                return posicao;
            }
            set
            {
                posicao = value;
            }
        }
    }
}
