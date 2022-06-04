using System.Diagnostics;
using System.Security.Cryptography;

string input = "ugkcyxxp";
int NumberOfChars = 8;
int counter = 0;
Stopwatch sw = new Stopwatch();

Console.WriteLine($"Part 1:");
sw.Start();
Queue<char> passwordQueue = new Queue<char>();
while (passwordQueue.Count < NumberOfChars)
{
    string currentHash = CreateMD5String(input + counter.ToString());
    if (CheckIfValidHash(currentHash))
    {
        Console.WriteLine($"{currentHash}: {currentHash[5]}");
        passwordQueue.Enqueue(currentHash[5]);
    }
    counter++;
}
sw.Stop();
Console.WriteLine($"Password is {CreatePasswordString(passwordQueue)}.");
Console.WriteLine($"Part 1 solved in {sw.ElapsedMilliseconds} milliseconds.");
sw.Reset();

Console.WriteLine("\n\n");
Console.WriteLine("Part 2:");
sw.Start();
char?[] passwordArray = new char?[NumberOfChars];
for (int i = 0; i < NumberOfChars; i++)
{
    passwordArray[i] = null;
}
counter = 0;

while (!CheckPasswordComplete(passwordArray))
{
    string currentHash = CreateMD5String(input + counter.ToString());
    if (CheckIfValidHashPartTwo(currentHash))
    {
        int pwPos = int.Parse(currentHash[5].ToString());
        if (passwordArray[pwPos] == null)
        {
            Console.WriteLine($"{currentHash}: {currentHash[5]} - {currentHash[6]}");
            passwordArray[pwPos] = currentHash[6];
        }
    }
    counter++;
}
sw.Stop();
Console.WriteLine($"Password is {CreatePasswordStringPartTwo(passwordArray)}.");
Console.WriteLine($"Part 2 solved in {sw.ElapsedMilliseconds} milliseconds.");

//Functions
bool CheckIfValidHash(string hash)
{
    string substr = hash.Substring(0, 5);
    if (substr == "00000")
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool CheckIfValidHashPartTwo(string hash)
{
    string substr = hash.Substring(0, 5);
    if (substr == "00000")
    {
        if (int.TryParse(hash[5].ToString(), out int result))
        {
            if(result >= 0 && result <= 7)
            {
                return true;
            }
        }
    }
    return false;
}

bool CheckPasswordComplete(char?[] arr)
{
    foreach (char? c in arr)
    {
        if(c == null)
        {
            return false;
        }
    }
    return true;
}

string CreateMD5String(string i)
{
    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(i);
    byte[] hashBytes = MD5.HashData(inputBytes);
    return Convert.ToHexString(hashBytes);
}

string CreatePasswordString(Queue<char> queue)
{
    string output = string.Empty;
    while(queue.Count > 0)
    {
        output += queue.Dequeue();
    }
    return output;
}

string CreatePasswordStringPartTwo(char?[] arr)
{
    string output = string.Empty;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != null)
        {
            output += arr[i];
        }
    }
    return output;
}