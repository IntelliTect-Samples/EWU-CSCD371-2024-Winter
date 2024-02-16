using System.Text;
using System.Linq;

namespace GenericsHomework;

    public class VennDiagram<T>(string Name, List<Circle<T>>? Circles = null)
{
    public List<Circle<T>> Circles { get; private set; } = Circles ?? [];
    public string Name { get; } = Name;

    public void AddCircles(Circle<T> circle)
    {
        ArgumentNullException.ThrowIfNull(circle);
        Circles.Add(circle);
    }
    public Circle<string> Intersection(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        if (Circles.Count == 0)
            return $"{Name}: {{}}";

        StringBuilder circles = new();

        foreach(Circle<T> circle in Circles[0..^1])
        {
            circles.Append($"{circle}, ");
        }

        circles.Append($"{Circles[^1]}");

        return circles.ToString();
    }

    }
