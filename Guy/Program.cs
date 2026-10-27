using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Guy
{
    public string Name;
    public int Cash;
    /// <summary>
    /// Wyświetla w konsoli imię oraz sianko posiadane
    /// </summary>
    public void WriteMyInfo()
    {
        Console.WriteLine(Name + " ma " + Cash + " zł. ");
    }
    /// <summary>
    /// Przekazuje pieniądze i usuwa je z portfela lub wyświetla o braku środków 
    /// </summary>
    /// <param name="amount"> Przekazywana kwota</param>
    /// <returns>Ilość becelu wyjmowana z portfela lub 0 jeśli brak pieniedzy lub za małe</returns>
    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " Mówi: " + Cash + "nie jest poprawną kwotą");
            return 0;
        }
        if (amount > Cash)
        {
            Console.WriteLine(Name + " mówi: " + "nie mam wystarczających środków, aby ci dać " + amount + " zł. ");
            return 0;
        }
        Cash -= amount;
        return amount;
    }
    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " mówi: " + " nie przyjmę " + amount + "zł.");
        }
        else
        {
            Cash += amount;
        }

    }
    static void Main(string[] args)
    {
        Guy jacek = new Guy { Cash = 50, Name = "Jacek" };
        Guy bartek = new Guy { Cash = 100, Name = "Bartek" };
        while (true)
        {
            jacek.WriteMyInfo();
            bartek.WriteMyInfo();
            Console.Write("Podaj kwotę: ");
            string howMuch = Console.ReadLine();
            if (howMuch == "") return;

            if (int.TryParse(howMuch, out int amount)) 
            {
                Console.Write("Pieniądze ma przekazać :");
                string whichGuy = Console.ReadLine();
                if (whichGuy == "Jacek")
                {
                    int cashGiven = jacek.GiveCash(amount);
                    bartek.ReceiveCash(cashGiven);
                }
                else if (whichGuy == "Bartek")
                {
                    int cashGiven = bartek.GiveCash(amount);
                    jacek.ReceiveCash(cashGiven);
                }
                else
                {
                    Console.WriteLine("Wpisz 'Jacek' lub 'Bartek' ");
                }
            }

            else
            {
                Console.WriteLine("Wpisz kwotę (lub pusty wiersz, aby zakończyć). ");
            }
        }
    }
}








    

        
        

    
