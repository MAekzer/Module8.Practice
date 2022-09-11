using Module8.Practice;

byte tasknum;
Console.Write("Введите номер задания (1-3): ");
bool tryparse = Byte.TryParse(Console.ReadLine(), out tasknum);

if (tryparse)
{
    switch(tasknum)
    {
        case 1:
            Console.Write("Введите путь директории: ");
            Task1to3Class.CleanDir(Console.ReadLine());
            break;

        case 2:
            Console.Write("Введите путь директории: ");
            Console.WriteLine($"Размер папки: {Task1to3Class.CountSize(Console.ReadLine())} байт");
            break;

        case 3:
            Console.Write("Введите путь директории: ");
            Task1to3Class.CountAndClean(Console.ReadLine());
            break;

        default:
            Console.WriteLine("Эта программа поддерживает только задания 1-3, попробуйте еще раз");
            break;
    }
}
else
{
    Console.WriteLine("Некоректный формат ввода, попробуйте еще раз.");
}
