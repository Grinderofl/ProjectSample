using System;

namespace ProjectSample.Infrastructure.Domain.Base
{
    public abstract class Entity
    {
        public virtual DateTime LastModified { get; set; } = DateTime.Now;
    }

    public abstract class Entity<TPk> : Entity, IEquatable<Entity<TPk>>
    {
        public virtual TPk Id { get; set; }

        /// <summary>
        ///     Indicates whether the current <see cref="T:FluentNHibernate.Data.Entity" /> is equal to another
        ///     <see cref="T:FluentNHibernate.Data.Entity" />.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="obj" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="obj">An Entity to compare with this object.</param>
        public virtual bool Equals(Entity<TPk> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return obj.Id.Equals(Id);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="T:FluentNHibernate.Data.Entity" /> is equal to the current
        ///     <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     true if the specified <see cref="T:FluentNHibernate.Data.Entity" /> is equal to the current
        ///     <see cref="T:System.Object" />; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />. </param>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj" /> parameter is null.</exception>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals((Entity<TPk>) obj);
        }

        /// <summary>
        ///     Serves as a hash function for a Entity.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode() => (Id.GetHashCode()*397) ^ GetType().GetHashCode();

        public static bool operator ==(Entity<TPk> left, Entity<TPk> right) => Equals(left, right);

        public static bool operator !=(Entity<TPk> left, Entity<TPk> right) => !Equals(left, right);
    }
}