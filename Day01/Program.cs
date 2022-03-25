using Day01;
using System.Diagnostics;

//Starting timer
Stopwatch sw = new Stopwatch();
sw.Start();
Console.WriteLine("Advent of Code Day 01");

string input = File.ReadAllText("./input.txt");
bool printDebug = false;

List<Instruction> instructions = new List<Instruction>();
foreach (string item in input.Split(", "))
{
    string dist = item.Remove(0, 1);
    int distInt = int.Parse(dist);
    Instruction newInstruction = new Instruction
    {
        Direction = item[0],
        Blocks = distInt
    };
    instructions.Add(newInstruction);
}

int heading = 360;
Vector2 pos = new Vector2(0, 0); //X,Y
List<string> visited = new List<string>();
Vector2 firstDouble = new Vector2(0,0);
bool foundPartTwo = false;

foreach (Instruction instruction in instructions)
{
    //Calculate direction
    if(heading == 0)
    {
        heading = 360;
    }
    if(instruction.Direction == 'L')
    {
        heading -= 90;
    }else if(instruction.Direction == 'R')
    {
        heading += 90;
    }
    if(heading < 0)
    {
        heading = 360 - heading;
    }else if(heading > 360)
    {
        heading = heading - 360;
    }

    if (printDebug)
    {
        Console.WriteLine($"Instruction: \t\t{instruction.Direction}{instruction.Blocks}");
        Console.WriteLine($"Direction: \t\t{heading}");
        Console.WriteLine($"Moving \t\t\t{instruction.Blocks} blocks");
    }

    for (int i = 0; i < instruction.Blocks; i++)
    {
        if (heading == 0 || heading == 360)
        {
            pos.X++;
        }
        else if (heading == 180)
        {
            pos.X--;
        }
        else if (heading == 90)
        {
            pos.Y++;
        }
        else if (heading == 270)
        {
            pos.Y--;
        }
        if (printDebug)
        {
            Console.WriteLine($"Current position: \t{pos}");
        }

        if (!visited.Contains(pos.ToString()))
        {
            visited.Add(pos.ToString());
        }
        else
        {
            if (!foundPartTwo)
            {
                //Console.WriteLine($"Double position: {pos.ToString()}");
                firstDouble = new Vector2(pos.X, pos.Y);
                foundPartTwo = true;
            }
        }
    }
    
    if (printDebug)
    {
        Console.WriteLine();
        Console.ReadLine();
    }
}

int distToTarget = Math.Abs(pos.X) + Math.Abs(pos.Y);
int distToPartTwo = Math.Abs(firstDouble.X) + Math.Abs(firstDouble.Y);
sw.Stop();
Console.WriteLine($"Part one: {distToTarget}, took {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Part two: {distToPartTwo}, took {sw.ElapsedMilliseconds} ms");