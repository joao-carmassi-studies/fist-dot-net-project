// List<string> listaDasBandas = ["BMTH", "System"];
Dictionary<string, List<int>> listaDeBandas = [];
listaDeBandas.Add("BMTH", [2, 4, 6, 8]);
listaDeBandas.Add("System", [1, 3, 5, 7]);

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
  Console.WriteLine("\nDigite 1 para adicionar uma banda");
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
      AvaliarBanda();
      break;
    case 4:
      Console.WriteLine("Você escolheu a quarta opção: exibir a média de uma banda");
      break;
    case 0:
      Console.WriteLine("Tchau tchau");
      break;
    default:
      Console.WriteLine("Opção inválida. Tente novamente.");
      ExibeMsgIrInicio();
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

//? Utils --------------------

void ListaBandas()
{
  int i = 1;
  foreach (string banda in listaDeBandas.Keys)
  {
    Console.WriteLine($"{i} - {banda}");
    i++;
  }
}

//? FuncoesMenu --------------------

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
  listaDeBandas.Add(nomeDaBanda, []);

  ExibeMsgIrInicio();
}

void ListaBandasRegistradas()
{
  Console.Clear();
  ExibeTitulo("Lista das bandas");
  ListaBandas();

  ExibeMsgIrInicio();
}

void AvaliarBanda()
{
  Console.Clear();
  ExibeTitulo("Selecione uma banda");
  ListaBandas();
  Console.Write("\nDigite o nome da banda: ");
  string nomeDaBanda = Console.ReadLine()!;

  if (!listaDeBandas.ContainsKey(nomeDaBanda))
  {
    Console.WriteLine($"A banda {nomeDaBanda} não existe");
    ExibeMsgIrInicio();
  }

  Console.Clear();
  ExibeTitulo($"De uma nota para {nomeDaBanda}");
  Console.Write("Nota: ");
  int nota = int.Parse(Console.ReadLine()!);
  listaDeBandas[nomeDaBanda].Add(nota);
  Console.WriteLine($"Vc deu nota {nota} para a banda {nomeDaBanda}");
  ExibeMsgIrInicio();
}

ExibirLogo();
ExibirMenu();