using System;

namespace DotNetCore.Objects
{
    public abstract class Entity : IEquatable<Entity>
    {
        public long Id { get; protected set; }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (GetType().GetHashCode() * 97) ^ Id.GetHashCode();
            }
        }
    }
}
