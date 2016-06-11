using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.EF.Infrastructure.Domain.Base
{
    public class Entity
    {
        public virtual DateTime LastModified { get; set; } = DateTime.Now;
    }

    public abstract class Entity<TPk> : Entity, IEquatable<Entity<TPk>>
    {
        public virtual TPk Id { get; set; }

        public virtual bool Equals(Entity<TPk> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return obj.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals((Entity<TPk>)obj);
        }

        public override int GetHashCode() => (Id.GetHashCode() * 397) ^ GetType().GetHashCode();

        public static bool operator ==(Entity<TPk> left, Entity<TPk> right) => Equals(left, right);

        public static bool operator !=(Entity<TPk> left, Entity<TPk> right) => !Equals(left, right);
    }
}