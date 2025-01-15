using System.Text.RegularExpressions;

string car_number;
string rgn;
string new_number = "";
string region = "";
string[] msk = new string[] {"77", "97",
"99", "177", "197", "199", "777", "797", "799", "977", "277", "297", "299"};
string[] spb = new string[] { "78", "98", "178", "198" };


var many_date = new Dictionary<char, char>()
{
    {'А', 'A'},
    {'В', 'B'},
    {'Е', 'E'},
    {'К', 'K'},
    {'М', 'M'},
    {'О', 'O'},
    {'С', 'C'},
    {'У', 'Y'},
    {'Х', 'X'}
};

car_number = (Console.ReadLine().ToUpper());
if(car_number.Length == 9) { rgn = $"{car_number[6]}" + $"{car_number[7]}" + $"{car_number[8]}"; }
else if(car_number.Length == 8) { rgn = $"{car_number[6]}" + $"{car_number[7]}"; }
else { Console.WriteLine("Некорректный ввод!"); rgn = "0"; }

if(rgn != "0") 
{
    Regex check1 = new Regex(@"[А,В,Е,К,М,Н,О,Р,С,Т,У,Х]{1}[0-9]{3}[А,В,Е,К,М,Н,О,Р,С,Т,У,Х]{2}[0-9]{2,3}");
    Regex check2 = new Regex(@"[A,B,E,K,M,H,O,P,C,T,Y,X]{1}[0-9]{3}[A,B,E,K,M,H,O,P,C,T,Y,X]{2}[0-9]{2,3}");

    if (check1.IsMatch(car_number))
    {
        new_number += many_date[car_number[0]];
        new_number += car_number[1];
        new_number += car_number[2];
        new_number += car_number[3];
        new_number += many_date[car_number[4]];
        new_number += many_date[car_number[5]];
        new_number += car_number[6];
        new_number += car_number[7];
        if (car_number.Length == 9)
        {
            new_number += car_number[8];
        }

        if (msk.Contains(rgn))
        {
            region = "Москва";
        }
        else if (spb.Contains(rgn))
        {
            region = "Санкт-Петербург";
        }
        else
        {
            region = "Регион";
        }

        Console.Write($"Номер {new_number: ?} регион: {region} соответствует формату.");
    }
    else if (check2.IsMatch(car_number))
    {
        Console.Write($"Номер {car_number: ?} регион: {region} соответствует формату.");

    }
    else { Console.Write($"Номер {car_number} не соответствует формату."); }

    Console.ReadLine();
}
