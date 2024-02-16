using System.Text;
using System.Linq;
using System.Globalization;

namespace GenericsHomework;

    public class VennDiagram<T>(string Name, int NumCircles = 2)
{
    public List<Circle<T>> Circles { get; private set; } = [];
    public string Name { get; } = Name ?? throw new ArgumentNullException(nameof(Name));

    public int NumCircles { get; } = NumCircles < 2 ? throw new ArgumentException("NumCircles can't be less than 2 is les than 2") : NumCircles;

    public void Add(Circle<T> circle)
    {
        ArgumentNullException.ThrowIfNull(circle);

        if (Exists(circle.Name))
        {
            throw new ArgumentException("Name of circle already exists within Diagram", nameof(circle));
        }
        if(Circles.Count + 1 > NumCircles)
        {
            throw new InvalidOperationException("Number of circles have been reached!");
        }

        Circles.Add(circle);
    }

    public bool Exists(string name)
    {
        List<string> circleNames = Circles.Where(circle => circle.Name == name).Select(circle => circle.Name).ToList();

        return circleNames.Count != 0;
    }

    public override string ToString()
    {
        if (Circles.Count == 0)
            return $"{Name}: {{}}";

        StringBuilder circles = new();

        foreach(Circle<T> circle in Circles[0..^1])
        {
            circles.Append(CultureInfo.InvariantCulture,$"{circle}, ");
        }

        circles.Append(CultureInfo.InvariantCulture, $"{Circles[^1]}");

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
