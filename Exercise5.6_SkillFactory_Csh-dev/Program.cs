// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Xml.Linq;

//5.6. Итоговый проект
var userData = GetUserData();
ShowData(userData);
Console.ReadKey();

static (string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] FavColors) GetUserData()
{
    (string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] FavColors) User;
    User = (Name: "Безимени", LastName: "Безфамилии", Age: 0, HasPet: false, Pets: new string[] { "" }, FavColors: new string[] { "" });

    Console.WriteLine("Введите имя");
    User.Name = Console.ReadLine();

    Console.WriteLine("Введите фамилию");
    User.LastName = Console.ReadLine();

    string age;
    int intAge;
    do
    {
        Console.WriteLine("Введите возраст цифрами");
        age = Console.ReadLine();
    } while (CheckNum(age, out intAge));
    User.Age = intAge;

    string answer;
    do
    {
        Console.WriteLine("Есть ли у вас животные? Да или Нет");
        answer = Console.ReadLine().ToUpper();
    } while (!(answer.Contains("ДА") || answer.Contains("НЕТ")));
    switch (answer)
    {
        case "ДА":
            User.HasPet = true;
            string petsCount;
            int intPetsCount;
            do
            {
                Console.WriteLine("Введите количество питомцев");
                petsCount = Console.ReadLine();
            } while (CheckNum(petsCount, out intPetsCount));
            User.Pets = CreateArrayPets(intPetsCount);
            break;
        case "НЕТ":
            User.HasPet = false;
            break;
    }

    string favColorCount;
    int intFavColorCount;
    do
    {
        Console.WriteLine("Введите количество Ваших любимых цветов цифрами");
        favColorCount = Console.ReadLine();
    } while (CheckNum(favColorCount, out intFavColorCount));
    User.FavColors = new string[intFavColorCount];
    User.FavColors = CreateArrayFavFlowers(intFavColorCount);

    return User;
}


static string[] CreateArrayPets(int num)
{
    var result = new string[num];
    for (int j = 0; j < num; j++)
    {
        Console.WriteLine("Введите имя питомца номер {0}", j + 1);
        result[j] = Console.ReadLine();
    }
    return result;
}

static string[] CreateArrayFavFlowers(int num)
{
    var result = new string[num];
    for (int j = 0; j < num; j++)
    {
        Console.WriteLine("Введите название любимого цвета под номером номер {0}", j + 1);
        result[j] = Console.ReadLine();
    }
    return result;
}


static bool CheckNum(string number, out int corrNumber)
{
    if (int.TryParse(number, out int intnum))
    {
        if (intnum > 0)
        {
            corrNumber = intnum;
            return false;
        }
    }
    corrNumber = 0;
    return true;
}

static void ShowData((string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] FavColors) User)
{
    Console.WriteLine("Ваше имя: {0}", User.Name);
    Console.WriteLine("Ваша фамилия: {0}", User.LastName);
    Console.WriteLine("Ваша возраст: {0}", User.Age);
    if (User.HasPet)
    {
        Console.WriteLine("У Вас есть питомцы, их количество: {0}", User.Pets.Length);
        for (int i = 0; i < User.Pets.Length; i++)
        {
            Console.WriteLine("Имя Вашего питомца под номером {0}: {1}", i + 1, User.Pets[i]);
        }
    }
    for (int i = 0; i < User.FavColors.Length; i++)
    {
        Console.WriteLine("Название Вашего любимого цвета под номером {0}: {1}", i + 1, User.FavColors[i]);
    }
}


