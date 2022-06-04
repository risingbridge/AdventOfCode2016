using Day03;
using System.Text.RegularExpressions;

List<string> input = File.ReadAllLines("./input.txt").ToList();
for (int i = 0; i < input.Count; i++)
{
    input[i] = Regex.Replace(input[i], @"\s+", " ");
}
List<Triangle> triangles = new List<Triangle>();
//part 1
foreach (string item in input)
{
    string[] itemArr = item.Split(" ");
    int x = int.Parse(itemArr[1]);
    int y = int.Parse(itemArr[2]);
    int z = int.Parse(itemArr[3]);

    Triangle tri = new Triangle(x, y, z);
    triangles.Add(tri);
}

int possibleTriangleCount = 0;
foreach (Triangle triangle in triangles)
{
    bool isValid = CheckValidTriangle(triangle);
    //Console.WriteLine($"Triangle: {triangle} - {isValid}");
    if (isValid)
    {
        possibleTriangleCount++;
    }
}
Console.WriteLine($"Valid triangles: {possibleTriangleCount}");

bool CheckValidTriangle(Triangle tri)
{
    int x = tri.x;
    int y = tri.y;
    int z = tri.z;
    if(x + y <= z)
    {
        return false;
    }else if(x + z <= y)
    {
        return false;
    }else if(y + z <= x)
    {
        return false;
    }
    else
    {
        return true;
    }
}

//part 2
triangles.Clear();
possibleTriangleCount = 0;
for (int i = 0; i < input.Count; i += 3)
{
    string[] itemArrA = input[i].Split(" ");
    string[] itemArrB = input[i+1].Split(" ");
    string[] itemArrC = input[i+2].Split(" ");
    int x = int.Parse(itemArrA[1]);
    int y = int.Parse(itemArrB[1]);
    int z = int.Parse(itemArrC[1]);
    Triangle tri = new Triangle(x, y, z);
    triangles.Add(tri);
}
for (int i = 0; i < input.Count; i += 3)
{
    string[] itemArrA = input[i].Split(" ");
    string[] itemArrB = input[i + 1].Split(" ");
    string[] itemArrC = input[i + 2].Split(" ");
    int x = int.Parse(itemArrA[2]);
    int y = int.Parse(itemArrB[2]);
    int z = int.Parse(itemArrC[2]);
    Triangle tri = new Triangle(x, y, z);
    triangles.Add(tri);
}
for (int i = 0; i < input.Count; i += 3)
{
    string[] itemArrA = input[i].Split(" ");
    string[] itemArrB = input[i + 1].Split(" ");
    string[] itemArrC = input[i + 2].Split(" ");
    int x = int.Parse(itemArrA[3]);
    int y = int.Parse(itemArrB[3]);
    int z = int.Parse(itemArrC[3]);
    Triangle tri = new Triangle(x, y, z);
    triangles.Add(tri);
}
foreach (Triangle triangle in triangles)
{
    bool isValid = CheckValidTriangle(triangle);
    //Console.WriteLine($"Triangle: {triangle} - {isValid}");
    if (isValid)
    {
        possibleTriangleCount++;
    }
}
Console.WriteLine($"Valid triangles: {possibleTriangleCount}");