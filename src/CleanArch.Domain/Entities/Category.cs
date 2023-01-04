using CleanArch.Domain.Exceptions;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
        public IEnumerable<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        public Category(
            int id, 
            string name)
        {
            DomainExceptionValidations.When(
                id <= 0,
                "Invalid id. Id is required.");

            ValidateDomain(name);

            Name = name;
            Id = id;
        }

        public void Update(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        private static void ValidateDomain(string name)
        {
            DomainExceptionValidations.When(
                string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is required.");

            DomainExceptionValidations.When(
                name.Length < 3,
                "Invalid name. Minimum length is 3.");
        }
    }
}
