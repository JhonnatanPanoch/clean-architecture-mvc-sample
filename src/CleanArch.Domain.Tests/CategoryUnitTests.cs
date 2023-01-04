using CleanArch.Domain.Entities;
using CleanArch.Domain.Exceptions;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTests
    {
        [Fact(DisplayName = "Create category with valid parameters.")]
        public void CreateCategory_withValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should().NotThrow<DomainExceptionValidations>();
        }

        [Fact(DisplayName = "Create category with negative id value.")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid id. Id is required.");
        }

        [Fact(DisplayName = "Create category with a short name value.")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Minimum length is 3.");
        }

        [Fact(DisplayName = "Create category missing name value.")]
        public void CreateCategory_MissingNameValue_DomainExceptionMissingName()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create category with a null name value.")]
        public void CreateCategory_NullNameValue_DomainExceptionNullName()
        {
            Action action = () => new Category(1, null);

            action.Should().Throw<DomainExceptionValidations>().WithMessage("Invalid name. Name is required.");
        }
    }
}