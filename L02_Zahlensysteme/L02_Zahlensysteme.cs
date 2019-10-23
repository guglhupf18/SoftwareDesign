using System;
public class L02_Zahlensysteme
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bitte Zahl zur Umwandlung eingeben");
        Console.Write("> ");
        var number = Console.ReadLine();

        int hexal = ConvertDecimalToHexal(number);
        int dec = ConvertHexalToDecimal(hexal);


        Console.WriteLine(/*+ words + "\n" */ +hexal);
    }

    int ConvertDecimalToHexal(int dec)
    {
        int hex;
        for (int i = dec.length - 1; i >= 0; i--)
        {
            for (int j = 0; j < dec.length; j++)
            {
                hex = dec[i] * (6 ^ j);
            }
        }
        return hex;
    }
}