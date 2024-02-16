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
    public Circle<T> Intersection(string name, string firstCircleName, string secondCircleName)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(firstCircleName);
        ArgumentNullException.ThrowIfNull(secondCircleName);

        List<string> selecteCircles = [firstCircleName, secondCircleName];

        List<Circle<T>> intersectCircles =
        Circles.Where(circle => selecteCircles.Contains(circle.Name)).ToList();

        //If intersection count was less than 2, that means the names are not valid
        if (intersectCircles.Count < 2)
        {
            if (intersectCircles[0].Name == firstCircleName)
            {
                throw new ArgumentException("A non valid name for the second circle has been provided", nameof(secondCircleName));
            }
            else
            {
                throw new ArgumentException("A non valid name for the first circle has been provided", nameof(firstCircleName));
            }
        }


        IEnumerable<T> items = intersectCircles.First().Elements;

        foreach (var circle in intersectCircles.Skip(1))
        {
            items = items.Intersect(circle.Elements).ToList();
        }

        return new Circle<T>(name, items.ToList());
    }
}
