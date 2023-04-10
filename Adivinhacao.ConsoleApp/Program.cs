namespace Adivinhacao.ConsoleApp
{
    internal class Program
    {
        #region Requisito 1 - OK
        /*
            O computador pensará em um número, e você, jogador, precisará adivinhá-lo.
            A cada erro, a máquina lhe dirá se o número chutado foi
            maior ou menor do que o pensado.
            No acerto, deverá parabenizar o jogador.
        */
        #endregion

        #region Requisito 2 - OK
        /*
            Você também poderá escolher o nível de dificuldade do jogo, 
            e isso lhe dará mais ou menos oportunidades de chutar um número.
        */
        #endregion

        #region Requisito 3 - OK
        /*
            Ao final, se você ganhar, o computador lhe dirá quantos pontos você fez,
            baseando-se em quão bons eram seus chutes.
        */
        #endregion

        static void Main(string[] args)
        {
            ApresentarTitulo();

            int dificuldade = SelecionarDificuldade();

            Adivinhacao jogo = new Adivinhacao(dificuldade);

            while (true)
            {
                int palpite = ObterPalpite();

                if (jogo.JogadorAcertou(palpite) || jogo.JogadorPerdeu())
                {
                    ApresentarMensagem(jogo.MensagemFinal);
                    break;
                }

                ApresentarMensagem(jogo.MensagemDica);

                ApresentarMensagem(jogo.TotalDePontos);
            }

        }

        private static void ApresentarTitulo()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Bem-vindo(a) ao Jogo da Adivinhação *");
            Console.WriteLine("***************************************");
        }

        private static void ApresentarMensagem(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ReadLine();
        }

        private static int SelecionarDificuldade()
        {
            int nivelDificuldade;

            Console.WriteLine();
            Console.WriteLine("Escolha o nível de dificuldade: ");
            Console.WriteLine("(1) Fácil (2) Médio (3) Difícil");
            Console.Write("Escolha: ");

            nivelDificuldade = Convert.ToInt32(Console.ReadLine());
            return nivelDificuldade;
        }

        private static int ObterPalpite()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Qual o seu chute? ");
            string chute = Console.ReadLine();

            int numeroChute = Convert.ToInt32(chute);

            return numeroChute;
        }
    }
}