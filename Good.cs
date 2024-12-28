using System;

namespace OnlineStore
{
    internal class Good
    {
        public Good(string name)
        {
            if (name == null)
                throw new ArgumentNullException($"{nameof(name)} is null");

            Name = name;
        }

        public string Name { get; }
    }
}