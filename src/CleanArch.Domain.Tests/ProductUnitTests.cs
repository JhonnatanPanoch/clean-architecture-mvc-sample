using CleanArch.Domain.Entities;
using CleanArch.Domain.Exceptions;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact(DisplayName = "Create product with valid parameters.")]
        public void CreateProduct_withValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().NotThrow<DomainExceptionValidations>();
        }

        [Fact(DisplayName = "Create product with invalid id value.")]
        public void CreateProduct_IdWithZeroValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(0, "Product Name", "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid id. Id is required.");
        }

        [Fact(DisplayName = "Create product with negative id value.")]
        public void CreateProduct_NegativeIdValue_DomainExceptionNegativeId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid id. Id is required.");
        }

        [Fact(DisplayName = "Create product with too short name value.")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Name minimum length is 3.");
        }

        [Fact(DisplayName = "Create product with null name value.")]
        public void CreateProduct_NullNameValue_DomainExceptionNullName()
        {
            Action action = () => new Product(1, null, "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create product with empty name value.")]
        public void CreateProduct_MissingNameValue_DomainExceptionMissingName()
        {
            Action action = () => new Product(1, "     ", "Product description", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create product with too short description value.")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptinShortDescription()
        {
            Action action = () => new Product(1, "Product name", "Pr", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid description. Description minimum length is 3.");
        }

        [Fact(DisplayName = "Create product with null description value.")]
        public void CreateProduct_NullDescriptionValue_DomainExceptionNullDescription()
        {
            Action action = () => new Product(1, "Product name", null, 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Create product with empty description value.")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionMissingDescription()
        {
            Action action = () => new Product(1, "Product name", "      ", 5, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Create product with zero price value.")]
        public void CreateProduct_PriceWithZeroValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product name", "Product description", 0, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid price. Price must be bigger than 0.");
        }

        [Fact(DisplayName = "Create product with negative price value.")]
        public void CreateProduct_NegativePriceValue_DomainExceptionNegativePrice()
        {
            Action action = () => new Product(1, "Product name", "Product description", -1, 10, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid price. Price must be bigger than 0.");
        }

        [Fact(DisplayName = "Create product with negative stock value.")]
        public void CreateProduct_NegativeStockValue_DomainExceptionNegativeStock()
        {
            Action action = () => new Product(1, "Product name", "Product description", 5, -1, "C:\\Users\\Premiersoft\\Desktop");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid stock. Stock can not be lower than 0.");
        }

        [Fact(DisplayName = "Create product with too long image value.")]
        public void CreateProduct_LongImageValue_DomainExceptionInvalidLongImage()
        {
            Action action = () => new Product(1, "Product name", "Product description", 5, 10, "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567891");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid image. Image max length is 250.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidations>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidations>();
        }
    }
}