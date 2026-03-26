using System.Security.Cryptography;

while (true)
{
  Console.Clear();

  Console.WriteLine("--------------------------");
  Console.WriteLine("Jogo de Adivinhação");
  Console.WriteLine("--------------------------");

  Console.Write("Digite um número: ");
  int num = Convert.ToInt32(Console.ReadLine());

  Console.WriteLine($"Numero digitado: {num}");

  int numAletorio = RandomNumberGenerator.GetInt32(1, 21);
  Console.WriteLine($"Numero aleatorio: {numAletorio}");

  if (num == numAletorio)
  {
    Console.WriteLine("--------------------------");
    Console.WriteLine("Parabens voce acertou");
    Console.WriteLine("--------------------------");
  }
  else if (num > numAletorio)
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

  Console.WriteLine("Deseja continuar jogando? [s/n] ");
  string? opcaoContinuar = Console.ReadLine();

  if (opcaoContinuar?.ToUpper() != "S")
  {
    break;
  }

  Console.ReadLine();

}
