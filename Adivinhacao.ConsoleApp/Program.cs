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
            int nivelDificuldade = 1, totalDeTentativas = 0;
            double totalDePontos = 1000;

            // Menu Principal
            Console.WriteLine("***************************************");
            Console.WriteLine("* Bem-vindo(a) ao Jogo da Adivinhação *");
            Console.WriteLine("***************************************");

            // Escolha de dificuldade
            Console.WriteLine();
            Console.WriteLine("Escolha o nível de dificuldade: ");
            Console.WriteLine("(1) Fácil (2) Médio (3) Difícil");
            Console.Write("Escolha: ");
            nivelDificuldade = Convert.ToInt32(Console.ReadLine());

            switch(nivelDificuldade)
            {
                case 1: 
                    totalDeTentativas = 15;
                    break;
                case 2:
                    totalDeTentativas = 10;
                    break;
                case 3:
                    totalDeTentativas = 5;
                    break;
            }

            // Gerando o número aleatório
            Random random = new Random();
            int numeroSecreto = random.Next(1, 21);

            for (int quantidadeChutes = 1; quantidadeChutes <= totalDeTentativas; quantidadeChutes++)
            {
                Console.Clear();

                Console.WriteLine($"Tentativa {quantidadeChutes} de {totalDeTentativas}");

                // Input do usuário
                Console.WriteLine();
                Console.WriteLine("Qual o seu chute? ");
                string chute = Console.ReadLine();

                int numeroChute = Convert.ToInt32(chute);

                bool acertou = numeroChute == numeroSecreto;
                bool menor = numeroChute < numeroSecreto;

                // Processamento
                if (acertou)
                {
                    Console.WriteLine("Parabéns, você acertou!");
                    Console.WriteLine($"Você fez {totalDePontos} pontos!");
                    break;
                }
                else if (menor)
                    Console.WriteLine("Seu chute foi menor que o número secreto");
                else
                    Console.WriteLine("Seu chute foi maior que o número secreto");

                double pontosPerdidos = Math.Abs((numeroChute - numeroSecreto) / 2);

                totalDePontos = totalDePontos - pontosPerdidos;

                Console.WriteLine($"Você fez {totalDePontos} pontos!");

                if (quantidadeChutes <= totalDeTentativas)
                    Console.WriteLine("Que azar! Tente novamente!");

                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}