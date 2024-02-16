
namespace GenericsHomework;

    public class Circle<T>
    {

        public Circle(List<T>? items = null)
        {
            Elements = items ?? [];
        }

        public List<T> Elements { get; private set; }

        public void Add(T newElement)
        {
            ArgumentNullException.ThrowIfNull(newElement);
            Elements.Add(newElement);
        }
        public override string ToString()
        {
            return Elements is null ? string.Empty : string.Join(", ", Elements);
        }

    }
