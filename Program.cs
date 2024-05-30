using System;
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
