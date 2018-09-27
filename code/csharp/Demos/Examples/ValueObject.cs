using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object other) {    // <-- 1
            return Equals(other as T);
        }

        protected abstract IEnumerable<object> 
            GetAttributesToIncludeInEqualityCheck();  // <-- 2

        public bool Equals(T other) {                 // <-- 3
            if (other == null) return false;

            return GetAttributesToIncludeInEqualityCheck()
                .SequenceEqual(
                    other.GetAttributesToIncludeInEqualityCheck());
        }

        public override int GetHashCode() {            // <-- 4
            var hash = 17;
            foreach (var obj in GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());

            return hash;
        }

        public static bool operator ==(ValueObject<T> left, 
            ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left,
            ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}