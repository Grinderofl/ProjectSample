namespace ProjectSample.EF.Infrastructure.Common.Models
{
    public class Identifier
    {
        private readonly string _identity;

        private Identifier(string identity)
        {
            _identity = identity;
        }

        public static explicit operator Identifier(string value) => new Identifier(value);
        public static implicit operator string(Identifier @this) => @this._identity;
    }
}