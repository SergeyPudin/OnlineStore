using System;

namespace OnlineStore
{
    internal class Good
    {
        public Good(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"{nameof(name)} is null or empty");

            Name = name;
        }

        public string Name { get; }
    }
}