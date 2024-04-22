using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
           
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Category With State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInValidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With State Name")]
        public void CreateCategory_WithInvalidParemeters_DomainExceptionInValidName()
        {
            Action action = () => new Category(1, "er");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres.");
        }
        [Fact(DisplayName = "Create Category With Null State Name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInValidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");

        }
        #endregion
    }
}