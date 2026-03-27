// v2:
// 1. Implemente a funcionalidade de Dificuldade e Tentativas limitadas
// 2. Implemente uma funcionalidade de Validação de Números Repetidos
// 3. Implemente uma funcionalidade de Pontuação

using System.Security.Cryptography;

while (true)
{

  ExibirCabecalho();

  Console.Write("\nEscolha um nível de dificuldade: ");
  int dificuldade = Convert.ToInt32(Console.ReadLine());


  int numeroMaximo;
  int tentativasMaximas;


  switch (dificuldade)
  {
    case 1:
      numeroMaximo = 20;
      tentativasMaximas = 10;
      break;

    case 2:
      numeroMaximo = 50;
      tentativasMaximas = 5;
      break;

    case 3:
      numeroMaximo = 100;
      tentativasMaximas = 3;
      break;

    default:
      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine("Por favor, selecione uma dificuldade válida.");
      Console.Write("Digite ENTER para continuar...");
      Console.ReadLine();
      continue;
  }

  int numAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

  int[] numerosDigitados = new int[tentativasMaximas];
  int contadorNumerosDigitados = 0;


  for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
  {

    Console.Clear();
    Console.WriteLine("--------------------------");
    Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}");
    Console.WriteLine("--------------------------");

    Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
    int num = Convert.ToInt32(Console.ReadLine());

    bool numeroEstaRepetido = false;

    for (int indiceChecado = 0; indiceChecado < numerosDigitados.Length; indiceChecado++)
    {
      if (numerosDigitados[indiceChecado] == num)
      {
        numeroEstaRepetido = true;
        break;
      }
    }

    if (numeroEstaRepetido == true)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine("Você já digitou esse número, tente novamente.");
      Console.WriteLine("------------------------------------");
      Console.Write("Digite ENTER para continuar...");
      Console.ReadLine();

      tentativa--;

      continue;
    }

    if (contadorNumerosDigitados < numerosDigitados.Length)
    {
      numerosDigitados[contadorNumerosDigitados] = num;
      contadorNumerosDigitados++;
    }

    if (num == numAleatorio)
    {
      Console.WriteLine("--------------------------");
      Console.WriteLine("Parabens você acertou");
      Console.WriteLine("--------------------------");

      break;
    }
    else if (num > numAleatorio)
    {
      Console.WriteLine("--------------------------");
      Console.WriteLine("O número digitado foi maior do que o número secreto!");
      Console.WriteLine("--------------------------");
    }
    else
    {
      Console.WriteLine("--------------------------");
      Console.WriteLine("O número digitado foi menor do que o número secreto!");
      Console.WriteLine("--------------------------");
    }

  }

  Console.WriteLine("Deseja continuar jogando? [s/n] ");
  string? opcaoContinuar = Console.ReadLine();

  if (opcaoContinuar?.ToUpper() != "S")
  {
    break;
  }

  Console.ReadLine();

}

static void ExibirCabecalho()
{
  Console.Clear();

  Console.WriteLine("--------------------------");
  Console.WriteLine("Jogo de Adivinhação");
  Console.WriteLine("--------------------------");
  Console.WriteLine("\nEscolha o nível de dificuldade");
  Console.WriteLine("-----------------------------------------------------");
  Console.WriteLine("1 - Fácil (10 tentativas)");
  Console.WriteLine("2 - Médio (5 tentativas)");
  Console.WriteLine("3 - Dificil (3 tentativas)");
  Console.WriteLine("-----------------------------------------------------");
}