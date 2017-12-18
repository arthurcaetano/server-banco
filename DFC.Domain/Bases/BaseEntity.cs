using System;
using FluentValidation;
using FluentValidation.Results;

namespace DFC.Domain.Bases
{
    public abstract class BaseEntity<T> : AbstractValidator<T> where T : BaseEntity<T>
    {
        protected BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; protected set; }

        public abstract bool EhValido();
        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            return !(compareTo is null) && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntity<T> a, BaseEntity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<T> a, BaseEntity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}