List<string> listaDasBandas = ["BMTH", "System"];

void ExibirLogo()
{
  Console.WriteLine(@"░██████╗░█████╗░██████╗░███████╗░█████╗░███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░███████║██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══██║██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗██║░░██║██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝");
  Console.WriteLine("\nBoas vindas ao Screan soung");
}

void ExibirMenu()
{
  Console.WriteLine("\nDigite 1 para mostrar uma banda");
  Console.WriteLine("Digite 2 para mostrar todas as bandas");
  Console.WriteLine("Digite 3 para avaliar uma banda");
  Console.WriteLine("Digite 4 para exibir a media de uma banda");
  Console.WriteLine("Digite 0 para sair");

  Console.Write("\nDigite a sua opção: ");
  string opcaoSelecionada = Console.ReadLine()!;
  int numeroOpcaoSelecionada = int.Parse(opcaoSelecionada);

  switch (numeroOpcaoSelecionada)
  {
    case 1:
      RegistraBanda();
      break;
    case 2:
      ListaBandasRegistradas();
      break;
    case 3:
      Console.WriteLine("Você escolheu a terceira opção: avaliar uma banda");
      break;
    case 4:
      Console.WriteLine("Você escolheu a quarta opção: exibir a média de uma banda");
      break;
    case 0:
      break;
    default:
      Console.WriteLine("Opção inválida. Tente novamente.\n");
      break;
  }
}

void ExibeTitulo(string titulo)
{
  int caracteres = titulo.Length;
  string separator = "".PadLeft(caracteres, '*');

  Console.WriteLine(separator);
  Console.WriteLine(titulo);
  Console.WriteLine(separator + '\n');
}

void ExibeMsgIrInicio()
{
  Console.WriteLine("\nAperte qualquer tecla para voltar para o menu inicial");
  Console.ReadKey();
  Console.Clear();
  ExibirLogo();
  ExibirMenu();
}

void RegistraBanda()
{
  Console.Clear();
  ExibeTitulo("Digite o nome da banda");
  string nomeDaBanda = Console.ReadLine()!;
  if (nomeDaBanda == "")
  {
    Console.Write("Nome da banda não pode estar vazio");
    Console.ReadKey();
    RegistraBanda();
  }
  Console.WriteLine($"A banda {nomeDaBanda} foi registrada!!!");
  listaDasBandas.Add(nomeDaBanda);

  ExibeMsgIrInicio();
}

void ListaBandasRegistradas()
{
  Console.Clear();
  ExibeTitulo("Lista das bandas");
  for (int i = 0; i < listaDasBandas.Count; i++)
  {
    Console.WriteLine($"{i} - {listaDasBandas[i]}");
  }

  ExibeMsgIrInicio();
}

ExibirLogo();
ExibirMenu();