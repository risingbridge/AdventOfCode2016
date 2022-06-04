//Starting timer
using Day02;
using System.Diagnostics;

Console.WriteLine("Advent of Code Day 02");
Stopwatch sw = new Stopwatch();
sw.Start();

List<string> input = File.ReadAllLines("./input.txt").ToList();
bool printKeypad = false;

//X ->      Y /\
Vector2 keypadPosition = new Vector2(1, 1);
List<int> bathroomCode = new List<int>();
int[,] keypad = new int[3, 3];
keypad[0, 0] = 1;
keypad[1, 0] = 2;
keypad[2, 0] = 3;
keypad[0, 1] = 4;
keypad[1, 1] = 5;
keypad[2, 1] = 6;
keypad[0, 2] = 7;
keypad[1, 2] = 8;
keypad[2, 2] = 9;

foreach (string s in input)
{
    foreach (char c in s)
    {
        switch (c)
        {
            case 'U':
                keypadPosition.Y--;
                if(keypadPosition.Y < 0)
                {
                    keypadPosition.Y = 0;
                }
                break;
            case 'D':
                keypadPosition.Y++;
                if(keypadPosition.Y > 2)
                {
                    keypadPosition.Y = 2;
                }
                break;
            case 'L':
                keypadPosition.X--;
                if(keypadPosition.X < 0)
                {
                    keypadPosition.X = 0;
                }
                break;
            case 'R':
                keypadPosition.X++;
                if(keypadPosition.X > 2)
                {
                    keypadPosition.X = 2;
                }
                break;
            default:
                break;
        }
    }

    if (printKeypad)
    {
        Console.ResetColor();
        for (int y = 0; y < keypad.GetLength(1); y++)
        {
            for (int x = 0; x < keypad.GetLength(0); x++)
            {
                if(x == keypadPosition.X && y == keypadPosition.Y)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(keypad[x, y]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    bathroomCode.Add(keypad[keypadPosition.X, keypadPosition.Y]);
}
string codeString = string.Empty;
foreach (int item in bathroomCode)
{
    codeString += item;
}
sw.Stop();
Console.WriteLine($"Part one: {codeString}, took {sw.ElapsedMilliseconds} ms");


sw.Reset();
Console.WriteLine("\n\n");
sw.Start();
//PART TWO

//X = Horisontal
//Y = Vertikal
//0 0 er top venstre
//     0 1 2 3 4
//0        1
//1      2 3 4
//2    5 6 7 8 9
//3      A B C
//4        D
Vector2 startPos = new Vector2(0, 2);
char?[,] keypadMap = new char?[5, 5];
for (int x = 0; x < 5; x++)
{
    for (int y = 0; y < 5; y++)
    {
        keypadMap[x, y] = null;
    }
}

keypadMap[2, 0] = '1';
keypadMap[1, 1] = '2';
keypadMap[2, 1] = '3';
keypadMap[3, 1] = '4';
keypadMap[0, 2] = '5';
keypadMap[1, 2] = '6';
keypadMap[2, 2] = '7';
keypadMap[3, 2] = '8';
keypadMap[4, 2] = '9';
keypadMap[1, 3] = 'A';
keypadMap[2, 3] = 'B';
keypadMap[3, 3] = 'C';
keypadMap[2, 4] = 'D';

Vector2 currentPos = startPos;
List<char?> finalCode = new List<char?>();

foreach (string s in input)
{
    foreach (char c in s)
    {
        Vector2 nextPos = new Vector2(currentPos.X, currentPos.Y);
        switch (c)
        {
            case 'U':
                nextPos.Y--;
                if (nextPos.Y < 0)
                {
                    nextPos.Y = 0;
                }
                break;
            case 'D':
                nextPos.Y++;
                if (nextPos.Y > 4)
                {
                    nextPos.Y = 4;
                }
                break;
            case 'L':
                nextPos.X--;
                if (nextPos.X < 0)
                {
                    nextPos.X = 0;
                }
                break;
            case 'R':
                nextPos.X++;
                if (nextPos.X > 4)
                {
                    nextPos.X = 4;
                }
                break;
            default:
                break;
        }
        if (keypadMap[nextPos.X, nextPos.Y] != null)
        {
            currentPos = nextPos;
        }
    }
    if (printKeypad)
    {
        PrintFancyKeypad(currentPos, s);
    }
    finalCode.Add(keypadMap[currentPos.X, currentPos.Y]);
}

Console.WriteLine();
codeString = string.Empty;
foreach (char? c in finalCode)
{
    if(c!= null)
    {
        codeString += c;
    }
}

sw.Stop();
Console.WriteLine($"Part two: {codeString}, took {sw.ElapsedMilliseconds} ms");

void PrintFancyKeypad(Vector2 pos, string s)
{
    Console.WriteLine($"Pos: {pos}");
    Console.WriteLine($"Rule: {s}");
    for (int y = 0; y < 5; y++)
    {
        for (int x = 0; x < 5; x++)
        {
            char? toPrint = keypadMap[x, y];
            if(pos.X == x && pos.Y == y)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (toPrint == null)
            {
                if(pos.X == x && pos.Y == y)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.Write(toPrint);
            }
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}