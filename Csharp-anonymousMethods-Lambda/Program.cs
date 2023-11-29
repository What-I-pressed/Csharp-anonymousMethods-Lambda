using System.Collections.Specialized;

GetRainbowColorRGB rainbowColorRGB = delegate (string color)
{
    color = color.ToLower();
    switch (color)
    {
        case "red":
            return new RGB(255, 0, 0);
        case "orange":
            return new RGB(255, 165, 0);
        case "yellow":
            return new RGB(255, 255, 0);
        case "green":
            return new RGB(0, 255, 0);
        case "blue":
            return new RGB(0, 127, 255);
        case "indigo":
            return new RGB(0, 0, 255);
        case "violet":
            return new RGB(139, 0, 255);
        default:
            return new RGB(0, 0, 0);
    }
};
string color = "RED";
RGB rgb = rainbowColorRGB(color);
rgb.Info();


Backpack backpack = new Backpack("Red", "Kite", "Cotton", 20, 15);
backpack.OnItemAdd += () => Console.WriteLine("Item added successfully");
backpack.Add(new Item("Bottle", 2));
backpack.Add(new Item("Pizza", 4));
backpack.Add(new Item("Laptop", 6));
backpack.Info();
try
{
    backpack.Add(new Item("Peanuts", 5));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}Console.WriteLine();

int[] arr = new int[] { -1, 24, -6, 14, 28, 9, -7, 10, -1 };
Console.WriteLine($"Number of numbers that multiples of 7 : {arr.Count(x => x % 7 == 0)}");
Console.WriteLine($"Number of positive numbers : {arr.Count(x => x > 0)}"); ;
var arrNegative = arr.Where(x => x < 0 && arr.Count(y => y == x) == 1);
Console.WriteLine($"Unique negative numbers : ");
foreach (var item in arrNegative) Console.WriteLine(item);
string text = "Hello my name is Anton!";
string word = "name";
Func<string, string, bool> check = (string text, string word) => text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Contains(word);
Console.WriteLine($"Does text '{text}' contain word '{word}' : {check(text, word)}");







class RGB
{
    int R { get; }
    int G { get; }
    int B { get; }

    public void Info()
    {
        if (R == 255 && G == 0 && B == 0) Console.WriteLine("Color is red");
        if (R == 255 && G == 165 && B == 0) Console.WriteLine("Color is orange");
        if (R == 255 && G == 255 && B == 0) Console.WriteLine("Color is yellow");
        if (R == 0 && G == 255 && B == 0) Console.WriteLine("Color is green");
        if (R == 0 && G == 127 && B == 255) Console.WriteLine("Color is blue");
        if (R == 0 && G == 0 && B == 255) Console.WriteLine("Color is indigo");
        if (R == 139 && G == 0 && B == 255) Console.WriteLine("Color is violet");
        if (R == 0 && G == 0 && B == 0) Console.WriteLine("Color is black");
    }

    public RGB(int r, int g, int b)
    {
        R = r; G = g; B = b;
    }
}

class Item
{
    public string Name { get; set; }
    public double Volume { get; set; }

    public Item(string name, double volume)
    {
        Name = name;
        Volume = volume;
    }
}

class Backpack
{
    public event Action OnItemAdd;
    public string Color { get; set; }
    public string Manufacturer { get; set; }
    public string FabricName { get; set; }
    public double Weight { get; set; }
    public int Volume { get; set; }
    public List<Item> Items { get; set; }
    public double FreeVolume { get; private set; }
    
    public Backpack(string color, string manufacturer, string fabricName,
        double weight, int volume)
    {
        Color = color;
        Manufacturer = manufacturer;
        FabricName = fabricName;
        Weight = weight;
        Volume = volume;
        FreeVolume = Volume;
        Items = new List<Item>();
    }

    public void Info()
    {
        Console.WriteLine($"Free volume : {FreeVolume} liters");
        foreach(var item in Items) Console.WriteLine(item.Name);
    }

    public void Add(Item item)
    {
        if(FreeVolume - item.Volume >= 0)
        {
            Items.Add(item);
            FreeVolume -= item.Volume;
            OnItemAdd?.Invoke();
            return;
        }
        throw new Exception("Backpack is already full");
    }
}

delegate RGB GetRainbowColorRGB(string color);