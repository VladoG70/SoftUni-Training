namespace _01_GenericBoxOfString
{
    public class Box<T>
        {

        public Box(T element)
            {
            this.Element = element;
            }

        public T Element { get; private set; }

        public override string ToString()
            {
            return $"{Element.GetType().FullName}: {this.Element}";
            }
        }
    }
