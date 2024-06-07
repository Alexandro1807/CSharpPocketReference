using System;
using System.Linq;
Console.WriteLine(MultiplyBy12(30));

int MultiplyBy12(int mult)
{
    return mult * 12;
}

static int Factorial(int x)
{
    if (x == 0) return 1;
    return x * Factorial(x);
}

AllClassElementsExample ALEE = new AllClassElementsExample("Строка", 55); //Вызов конструктора класса AllClassElementsExample с инициализаторами объектов
(string s, int x) = ALEE; //Деконструирование (вызов деконструктора)
var (_, x1) = ALEE; //Деконструирование с неявной типизацией + отбрасывание первой переменной (если она никогда не понадобится в дальнейшем)

string nameOf = nameof(x); //Возвращение имени типа переменной X (строка nameOf будет равна X)
nameOf = nameof(Console) + "." + nameof(Console.WriteLine); //Возвращение имени класса и имени члена-метода экземпляра

SuperClass sc = new SuperClass(); //Создание экземпляра базового класса
SubClass1 sc1 = sc as SubClass1; //Приведение вниз через операцию as

int x999 = 9;
object obj999 = x; //Упаковка int
int y999 = (int)obj999; //Распаковка int
long l999 = (long)(int)obj999; //Распаковка int, преобразование в long

Point p1 = new Point(); //Вызов структуры через неявный конструктор без параметров
Point p2 = new Point(1, 1); //Вызов определённого конструктора структуры

var stack = new Stack<int>(); //Создание экземпляра класса конкретного типа вместо обобщённого
stack.Push(5);
stack.Push(10);
int xStack = stack.Pop();
int уStack = stack.Pop();

static void Swap<T>(ref T a, ref T b) //Обобщённый метод по замене местами содержимого двух переменных любого типа T
{
    T temp = a;
    a = b;
    b = temp;
}

int хSwap = 5;
int уSwap = 10;
Swap(ref хSwap, ref уSwap);
Swap<int>(ref хSwap, ref уSwap);

Player player = new Player();
IWeapon[] inventory = { new Gun(), new LaserGun(), new Knife() };
foreach (var item in inventory)
{
    player.Fire(item);
    Console.WriteLine();
}
player.Throw(new Knife());

int Square(int x) => x * x; //Какой-то метод
int Cube(int x) => x * x * x; //Какой-то метод
int[] values = { 1, 2, 3 };
Transform(values, Square);
foreach (int i in values)
    Console.WriteLine(i + " ");
void Transform(int[] values, Transformer t)
{
    for (int i = 0; i < values.Length; i++)
        values[i] = t(values[i]);
}
Transformer t = Square; //Создание экземпляра делегата
int answerSquare = t(3); //Вызов экземпляра делегата по аналогии с вызовом метода

int factor = 2;
Func<int, int> multiplierFunc = n => n * factor; //Лямбда-выражение, захватывающее внешнюю переменную
static Func<int> Natural() //Делегат Func
{
    int seed = 0;
    return () => seed++; //Лямбда-выражение, возвращающее замыкание
}
Func<int> natural = Natural(); //Расширение времени жизни переменной seed
Console.WriteLine(natural()); //0
Console.WriteLine(natural()); //1
Console.WriteLine(natural()); //2
Console.WriteLine(natural()); //3

Func<int, int> multiplierFuncStatic = static n => n * 2; //Статическое лямбда-выражение

int? aTypeWithNull = null; //Тип значения, допускающий null
int bTypeWithNull = 2; //Тип значения, НЕ допускающий null
int? cTypeWithNull = aTypeWithNull + bTypeWithNull; //Смешивание типов, допускающих и не допускающих null
int? dTypeWithNull = aTypeWithNull ?? 5; //Операция объединения с null

var almostProgrammer = new { Name = "Sasha", Age = 26 }; //Анонимный тип

dynamic dynamicX = MultiplyBy12(12); //Динамический тип - компилятор выполняет динамическое связывание во время выполнения
var dynamicY = dynamicX.ToString(); //Компилятор не знает, существует ли метод ToString()

string[] LINQStrings = { "Проверка", "Слово", "Рак", "Торт", "Проверки" };
IEnumerable<string> LINQStringsWhere = LINQStrings.Where(n => n.Length >= 4); //Язык запросов LINQ
var LINQStringsQuery = from n in LINQStrings where n.Length >= 4 select n; //Синтаксис запроса
int LINQMatch = (from n in LINQStrings where n.Contains("о") select n).Count(); //Запрос со смешанным синтаксисом





//Пауза перед завершением консоли
Thread.Sleep(3 * 1000);



class AllClassElementsExample //Класс с различными примерами его элементов
{
    string Name; //Поле
    int X; //Поле
    public int Age = 10; //Публичное поле с инициализацией
    static readonly string TempFolder = System.IO.Path.GetTempPath(); //Инициализатор поля содержит выражение, вызывает метод
    public const string Message = "This is a const!"; //Константа
    decimal currentPrice; //Закрытое "поддерживающее" поле
    public decimal CurrentPrice //Открытое свойство (поле с логикой)
    {
        get { return currentPrice; } //Средство доступа GET. Чтение свойства. Возврат значения такого же типа, как и тип свойства
        set { currentPrice = value; } //Средство доступа SET. Присваивание свойству значения. Установка поля значением CurrentPrice. Value равно полю currentPrice
    }
    public decimal CurrentPrice1 => currentPrice; //Свойство, сжатое до выражения (только средство доступа GET - только для чтения)
    public decimal CurrentPrice2 //Свойство, средства доступа которого сжаты до выражения
    {
        get => currentPrice;
        set => currentPrice = value;
    }
    public decimal CurrentPrice3 { get; set; } = 123; //Автоматическое свойство, аналогичное свойству CurrentPrice, с наличием инициализатора свойства
    public decimal CurrentPrice4 { get; init; } = 100; //Средство доступа только для инициализации. Аналог свойства только для чтения, где значение устанавливается единожды через инициализатор объекта

    string[] words = "This text is for example".Split(); //Поле для индексатора
    public string this[int wordNum] { get { return words[wordNum]; } set { words[wordNum] = value; } } //Индексатор
    public string this[Index index] => words[index]; //Индексатор с поддержкой индексов ^1 и прочих
    public string[] this[Range range] => words[range]; //Индексатор с поддержкой диапазонов ..2, 2.. и прочих

    int Foo(int x, int y) => x * y * 2; //Метод, сжатый до выражения
    //Перегруженный метод
    void Foo(int x) { }
    void Foo(double x) { }
    void Foo(int x, float y) { }
    void Foo(float x, int y) { }
    public AllClassElementsExample(string nameOut = "") => Name = nameOut; //Конструктор, сжатый до выражения + код инициализации (установка поля) конструктора
    public AllClassElementsExample(string nameOut = "", int x = 0) : this(nameOut.ToUpper()) { X = x; } //Перегруженный конструктор, вызывающий другой конструктор через ссылку (ключевое слово) this
    static AllClassElementsExample() { Console.WriteLine("Type Initialized!"); } //Статический конструктор (может быть только один)
    public void Deconstruct (out string name, out int x) { name = Name; x = X; } //Деконструктор
    ~AllClassElementsExample() => Console.WriteLine("Finalizing!"); //Финализатор, сжатый до выражения - действия перед работой сборщика мусора
}

partial class PartialClass //PARTIAL - часть класса.Все части одного класса помечаются ключевым словом PARTIAL
{
    int x = 0;
    partial void Method(); //Частичный метод - объявление
    public partial void M1(); //Расширенный частичный метод - объявление (расширяется с помощью модификатора доступности)
}

partial class PartialClass //PARTIAL - часть класса.Все части одного класса помечаются ключевым словом PARTIAL
{
    int y = 0;
    partial void Method() //Частичный метод - реализация
    {
        Console.WriteLine("Вызван частичный метод - partial void Method()");
    }
    public partial void M1() //Расширенный частичный метод - объявление (расширяется с помощью модификатора доступности)
    {
        Console.WriteLine("Вызван расширенный частичный метод - public partial void M1()");
    }
}

public class SuperClass //Суперкласс - базовый класс, от которого наследуются другие классы
{
    public string Name;
    public SuperClass() { }
    public SuperClass(string name) { this.Name = name; } //Конструктор
}

public class SubClass1 : SuperClass //Подкласс - производный класс, который наследуется от другого класса
{
    public long Number;
    public SubClass1(string name) : base(name) { } //Наследование конструктора
}

public struct Point //Структура
{
    int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; } //Конструктор структуры
}

public enum BorderSides : int { Left, Right, Top, Bottom } //Перечисление

public class Stack<T> //Класс обобщённого типа <T>
{
    int position;
    T[] data = new T[100];
    public void Push(T obj) => data[position++] = obj;
    public T Pop() => data[--position];
}

interface IWeapon //Интерфейс. Класс только с методами или свойствами без реализации
{
    public void Fire();
}

interface IThrowingWeapon : IWeapon //Наследование интерфейса
{
    public void Throw();
}

interface IInterface : IThrowingWeapon, IWeapon //Множественное наследование интерфейса
{

}

class Gun : IWeapon //Реализация интерфейса (грубо: наследование интерфейса)
{
    public void Fire()
    {
        Console.WriteLine($"{GetType().Name}: Выстрел!");
    }
}

class LaserGun : IWeapon //Реализация интерфейса (грубо: наследование интерфейса)
{
    public void Fire()
    {
        Console.WriteLine($"{GetType().Name}: Пиу!");
    }
}

class Knife : IThrowingWeapon
{
    public void Fire()
    {
        Console.WriteLine($"{GetType().Name}: Ударил!");
    }

    public void Throw()
    {
        Console.WriteLine($"{GetType().Name}: Метнул!");
    }
}

class Player
{
    public void Fire(IWeapon weapon)
    {
        weapon.Fire();
    }

    public void Throw(IThrowingWeapon throwingWeapon)
    {
        throwingWeapon.Throw();
    }
}

delegate int Transformer(int x); //Делегат
public delegate void PriceCnahgedHandler(decimal oldPrice, decimal newPrice); //Определение делегата
public class Stock
{
    string symbol;
    decimal price;
    public Stock(string symbol) => this.symbol = symbol;
    public event PriceCnahgedHandler PriceCnahged; //Объявление события
    public decimal Price
    {
        get => price;
        set
        {
            if (price == value) return; //Выйти, если ничего не изменилось
            decimal oldPrice = price;
            price = value;
            if (PriceCnahged != null) PriceCnahged(oldPrice, price); //Запустить событие, если список вызова НЕ пуст
        }
    }
}

public struct Note //Структура
{
    int value;
    public Note(int semitonesFromA) { value = semitonesFromA; }
    public static Note operator +(Note x, int semitones) //Перегрузка операции + через ключевое слово operator
    {
        return new Note(x.value + semitones);
    }
    public static Note operator -(Note x, int semitones) => new Note(x.value - semitones); //Перегрузка операции -, сжатая до выражения
}

class Finalizator : IDisposable //Класс с финализатором по освобождению ресурсов
{
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); //Не запускать финализатор в следующий цикл работы GC - Garbage Collector (сборщик мусора)
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //Например, вызвать Dispose на других объектах, которыми владеет данный экземпляр. Можно ссылаться на другие финализируемые объекты
        }
        //Например, освободить неуправляемые ресурсы, которыми владеет только этот объект
    }
    ~Finalizator() => Dispose(false);
}

class ThreadSafeEducation //Класс для темы "Параллелизм": "Блокировка и безопасность потоков"
{
    static bool _done; //Разделяемое поле
    static readonly object _locker = new object();
    public bool IsCancellationRequested { get; private set; } //Свойство - запрос отмены параллельной операции после её запуска
    public void Cancel() { IsCancellationRequested = true; } //Метод установки свойства в true
    public void ThrowlfCancellationRequested()
    {
        if (IsCancellationRequested) throw new OperationCanceledException(); //Отмена параллельной операции
    }

    static void Main()
    {
        new Thread(Go).Start();
        Go();
        Thread t1 = new Thread(() => Go1("From t1")); //Передача аргумента (данных) потоку
        void Go1(string param1) => Console.WriteLine(param1);
    }
    static void Go() //Безопасный в отношении потоков код
    {
        lock (_locker) //Монопольная блокировка на период чтения и записи разделяемого поля
        {
            if (!_done) { Console.WriteLine("Done!"); _done = true; }
        }
    }
    Task<int> GetPrimesCountAsync(int start, int count) //Асинхронный метод, который вычисляет и подсчитывает простые числа
    {
        return Task.Run(() =>
            ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
    }
    async void DisplayPrimesCount() //Асинхронная функция - модификатор async позволяет трактовать "await" как ключевое слово
    {
        int result = await GetPrimesCountAsync(2, 1000000); //Вызов асинхронного метода с помощью ключевого слова await
        Console.WriteLine(result);
        await foreach (var number in RangeAsync(0, 10, 500)) //Потребление асинхронного потока
            Console.WriteLine(number);
    }

    async IAsyncEnumerable<int> RangeAsync(int start, int count, int delay) //Асинхронный поток
    {
        for (int i = start; i < start + count; i++)
        {
            await Task.Delay(delay);
            yield return i;
        }
    }
}