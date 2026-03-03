var bandsList = new Dictionary<string, List<int>> {
  { "BMTH",  new List<int> { 2, 4, 6, 8 }  },
  { "System", new List<int> { 1, 3, 5, 7 }  }
};

void ShowLogo()
{
  Console.WriteLine(@"░██████╗░█████╗░██████╗░███████╗░█████╗░███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░███████║██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══██║██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗██║░░██║██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝");
  Console.WriteLine("\nWelcome to Screan Soung");
}

void ShowMenu()
{
  Console.WriteLine("\nType 1 to add a band");
  Console.WriteLine("Type 2 to show all bands");
  Console.WriteLine("Type 3 to rate a band");
  Console.WriteLine("Type 4 to show the average rating of a band");
  Console.WriteLine("Type 0 to exit");

  Console.Write("\nEnter your option: ");
  string selectedOption = Console.ReadLine()!;

  switch (selectedOption)
  {
    case "1":
      RegisterBand();
      break;
    case "2":
      ListRegisteredBands();
      break;
    case "3":
      RateBand();
      break;
    case "4":
      ShowBandAverage();
      break;
    case "0":
      Console.WriteLine("Goodbye");
      break;
    default:
      Console.WriteLine("Invalid option. Try again.");
      ShowReturnToMenuMsg();
      break;
  }
}

void ShowTitle(string title)
{
  int chars = title.Length;
  string separator = "".PadLeft(chars, '*');

  Console.WriteLine(separator);
  Console.WriteLine(title);
  Console.WriteLine(separator + '\n');
}

void ShowReturnToMenuMsg()
{
  Console.WriteLine("\nPress any key to return to the main menu");
  Console.ReadKey();
  Console.Clear();
  ShowLogo();
  ShowMenu();
}

//? Utils --------------------

void ListBands()
{
  int i = 1;
  foreach (string band in bandsList.Keys)
  {
    Console.WriteLine($"{i} - {band}");
    i++;
  }
}

//? Menu Functions --------------------

void RegisterBand()
{
  Console.Clear();
  ShowTitle("Enter the band name");
  string bandName = Console.ReadLine()!;
  if (bandName == "")
  {
    Console.Write("Band name cannot be empty");
    Console.ReadKey();
    RegisterBand();
    return;
  }
  Console.WriteLine($"The band {bandName} has been registered!");
  bandsList.Add(bandName, new List<int>());

  ShowReturnToMenuMsg();
}

void ListRegisteredBands()
{
  Console.Clear();
  ShowTitle("List of bands");
  ListBands();

  ShowReturnToMenuMsg();
}

void RateBand()
{
  Console.Clear();
  ShowTitle("Select a band to rate");
  ListBands();
  Console.Write("\nEnter the band name: ");
  string bandName = Console.ReadLine()!;

  if (!bandsList.ContainsKey(bandName))
  {
    Console.WriteLine($"The band {bandName} does not exist");
    ShowReturnToMenuMsg();
    return;
  }

  Console.Clear();
  ShowTitle($"Give a rating to {bandName}");
  Console.Write("Rating: ");
  int rating = int.Parse(Console.ReadLine()!);
  bandsList[bandName].Add(rating);
  Console.WriteLine($"You gave a rating of {rating} to the band {bandName}");
  ShowReturnToMenuMsg();
}

void ShowBandAverage()
{
  Console.Clear();
  ShowTitle("Select a band to see the average rating");
  ListBands();
  Console.Write("\nEnter the band name: ");
  string bandName = Console.ReadLine()!;

  if (!bandsList.ContainsKey(bandName))
  {
    Console.WriteLine($"The band {bandName} does not exist");
    ShowReturnToMenuMsg();
    return;
  }

  double average = bandsList[bandName].Average();
  Console.WriteLine($"The average rating for {bandName} is {average}");
  ShowReturnToMenuMsg();
}

ShowLogo();
ShowMenu();