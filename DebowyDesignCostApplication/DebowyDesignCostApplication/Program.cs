using DebowyDesignCostApplication;

Console.WriteLine("Witaj w programie do wyliczania statystyki dochodu miesięcznego w DębowyDesign!");
Console.WriteLine();
Console.WriteLine("Pamiętaj, że jeśli chcesz wyjść to wpisz q");
Console.WriteLine();
Console.WriteLine("Gotowy? (potwierdź jakim kolwiek klawiszem)");
Console.WriteLine();

var inputKey = Console.ReadKey();

if (inputKey != null)
    Console.Clear();

Console.WriteLine("Wybierz co chcesz zrobić (zatwierdź klawiszem enter):");
Console.WriteLine("1. Dodać zarobioną kwotę");
Console.WriteLine("2. Wyświetlić statystyki dla danego miesiąca");
Console.WriteLine();

var currentMonth = new EarningMonthInFile("");

currentMonth.MoneyAdded += MoneyAdded;

var menuInput = Console.ReadLine();

switch (menuInput)
{
    case "1":
        Console.Clear();
        Console.WriteLine("Podaj miesiąc rozliczeniowy: ");
        Console.WriteLine();

        var monthInput = Console.ReadLine().ToLower();

        if (monthInput != null)
        {
            currentMonth = new EarningMonthInFile(monthInput);
        }

        while (true)
        {
            Console.WriteLine("Podaj kolejną kwotę:");
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }

            try
            {
                currentMonth.AddMoney(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception catched: {ex.Message}");
            }
        }
        break;
    case "2":
        Console.Clear();
        Console.WriteLine("Podaj miesiąc rozliczeniowy: ");
        Console.WriteLine();

        var monthInputToStatistics = Console.ReadLine().ToLower();

        currentMonth = new EarningMonthInFile(monthInputToStatistics);

        Console.Clear();

        Console.WriteLine($"Statystyki zarobków w {monthInputToStatistics}");
        Console.WriteLine();

        var statistics = currentMonth.GetStatistics();
        Console.WriteLine($"Średnia zarobiona kwota: {statistics.Average:N2}");
        Console.WriteLine($"Minimalny zarobek: {statistics.Min}");
        Console.WriteLine($"Maksymalny zarobek: {statistics.Max}");

        if (statistics.AverageNetSalary == true)
            Console.WriteLine("Zarobek w tym miesiącu jest większy od średniej krajowej wypłaty.");
        else
            Console.WriteLine("Zarobek w tym miesiącu jest mniejszy niż średnia krajowa wypłata.");

        if (statistics.MiminumNetSalary == true)
            Console.WriteLine("Zarobek w tym miesiącu jest większy od minimalnej krajowej wypłaty.");
        else
            Console.WriteLine("Zarobek w tym miesiącu jest mniejszy od minimalnej krajowej wypłaty.");  
        break;
}


void MoneyAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano zarobioną kwotę.");
}