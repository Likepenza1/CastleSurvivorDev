using System;
using Core.Extensions;

namespace CoreExtension
{
    public static class RandomExtensions
    {
        private static readonly Random Random = new();
        
        public static bool GetBool(Random random)
        {
            return random.Next(0, 2) == 0;
        }
        
        public static bool GetBool()
        {
            return GetBool(Random);
        }

        public static int InRange(int fromInclusive, int toExclusive)
        {
            return Random.Next(fromInclusive, toExclusive);
        }
        
        public static float InRange(float fromInclusive, float toExclusive)
        {
            return Random.NextFloat(fromInclusive, toExclusive);
        }
    }
}