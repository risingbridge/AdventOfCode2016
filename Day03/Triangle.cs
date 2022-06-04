namespace Day03;
public class Triangle
{
    public Triangle(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }

    public override string ToString()
    {
        string output = $"{x},{y},{z}";
        return output;
    }

}
