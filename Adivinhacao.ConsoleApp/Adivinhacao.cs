using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinhacao.ConsoleApp
{
    public class Adivinhacao

    {
        public string MensagemFinal { get; set; } = "";
        public string MensagemDica { get; set; } = "";

        public string TotalDePontos
        {
            get
            {
                return $"Você fez {pontos} pontos.";
            }
        }

        private int TentativasRestantes
        {
            get
            {
                switch (dificuldade)
                {
                    case 1:
                        return 15;
                    case 2:
                        return 10;
                    case 3:
                        return 5;
                    default:
                        return 15;
                }
            }
        }

        private double pontos;

        private int tentativas;

        private int dificuldade;

        private int numeroSecreto;

        public Adivinhacao(int dificuldade)
        {
            numeroSecreto = new Random().Next(1, 21);
            tentativas = 0;

            this.dificuldade = dificuldade;
            pontos = 1000;
        }

        public bool JogadorAcertou(int palpite)
        {
            if (palpite == numeroSecreto)
            {
                MensagemFinal = $"Parabéns, você acertou em {tentativas + 1} tentativas!";
                return true;
            }
            else if (palpite < numeroSecreto)
                MensagemDica = "O palpite foi menor que o número secreto!";
            else
                MensagemDica = "O palpite foi maior que o número secreto!";

            SubtrairPontos(palpite);

            tentativas++;

            return false;
        }


        public bool JogadorPerdeu()
        {
            if (tentativas == TentativasRestantes)
            {
                MensagemFinal = "Que azar! Você perdeu, tente novamente!";
                return true;
            }

            return false;
        }

        private void SubtrairPontos(int palpite)
        {
            double pontosPerdidos = Math.Abs((palpite - numeroSecreto) / 2);

            pontos -= pontosPerdidos;
        }
    }
}
