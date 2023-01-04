using CleanArch.Domain.Exceptions;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(
            int id,
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainExceptionValidations.When(
               id <= 0,
               "Invalid id. Id is required.");

            ValidateModel(
                name,
                description,
                price,
                stock,
                image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            ValidateModel(
                name, 
                description,
                price, 
                stock,
                image);

            Name = name;
            Description= description;
            Price= price;
            Stock= stock;
            Image= image;
        }

        public void Update(
            string name,
            string description,
            decimal price,
            int stock,
            string image,
            int categoryId)
        {
            DomainExceptionValidations.When(
               categoryId <= 0,
               "Invalid category id. Category Id is required.");

            ValidateModel(
                name,
                description,
                price,
                stock,
                image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private static void ValidateModel(
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainExceptionValidations.When(
                string.IsNullOrWhiteSpace(name), 
                "Invalid name. Name is required.");

            DomainExceptionValidations.When(
                name.Length < 3,
                "Invalid name. Name minimum length is 3.");

            DomainExceptionValidations.When(
                string.IsNullOrWhiteSpace(description),
                "Invalid description. Description is required.");

            DomainExceptionValidations.When(
                description.Length < 3,
                "Invalid description. Description minimum length is 3.");

            DomainExceptionValidations.When(
               price <= 0,
               "Invalid price. Price must be bigger than 0.");

            DomainExceptionValidations.When(
               stock < 0,
               "Invalid stock. Stock can not be lower than 0.");

            DomainExceptionValidations.When(
                string.IsNullOrWhiteSpace(image),
                "Invalid image. Image is required.");

            DomainExceptionValidations.When(
                image.Length > 250,
                "Invalid image. Image max length is 250.");
        }


    }
}