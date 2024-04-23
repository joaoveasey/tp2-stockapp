using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateCategoryWithValidParametersState()
        {
            Action action = () => new Product("teste", "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Valid State Id")]
        public void CreateCategoryWithValidParametersStateId()
        {
            Action action = () => new Product(4, "teste", "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName = "Create Product With Invalid State Id")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "teste", "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProductWithNullParametersDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "ts", "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProductWithNullParametersDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "teste", null, 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void CreateProductWithInvalidDescriptionParametersDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "teste", "test", 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "teste", "testando uma descrição", -10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "teste", "testando uma descrição", 10.00M, -3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Image Url")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidImageUrl()
        {
            Action action = () => new Product(1, "teste", "testando uma descrição", 10.00M, 3,
                new string('a', 251));
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        [Fact(DisplayName = "Create Product With Null State Image Url")]
        public void CreateProductWithNullParametersDomainExceptionInvalidImageUrl()
        {
            Action action = () => new Product("teste", "testando uma descrição", 10.00M, 3, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image url, image url is required.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Name - Too long")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidNameTooLong()
        {
            Action action = () => new Product(
                new string('a', 101)
                , "testando uma descrição", 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Description - Too long")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidDescriptionTooLong()
        {
            Action action = () => new Product(
                "teste", new string('a', 201)
                , 10.00M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too long, maximum 200 characters.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Price Format")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidPriceFormat()
        {
            Action action = () => new Product(1, "teste", "testando uma descrição", 10.999M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price, can only have 2 decimals places.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Price, Too Long")]
        public void CreateProductWithInvalidParametersDomainExceptionInvalidPriceTooLong()
        {
            Action action = () => new Product(1, "teste", "testando uma descrição", 99999999999.99M, 3, "teste.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price, too long, maximum value 999999999.99.");
        }
        #endregion
    }
}