
namespace GenericsHomework;

    public class Circle<T>(string Name , List<T>? items = null)
    {
        public string Name { get;} = Name ?? throw new ArgumentNullException(nameof(Name));
        public List<T> Elements { get; private set; } = items ?? [];

        public void Add(T newElement)
        {
            ArgumentNullException.ThrowIfNull(newElement);


            if (Elements.Contains(newElement))
                throw new ArgumentException($"{newElement} already exists in elements",nameof(newElement));

            Elements.Add(newElement);
        }

        public void Remove(T element)
        {
            ArgumentNullException.ThrowIfNull(element);

            Elements.Remove(element);

        }

        public override string ToString()
        {
            return Elements is null ? string.Empty : $"{Name}: {{{string.Join(", ", Elements)}}}";
        }

    }
