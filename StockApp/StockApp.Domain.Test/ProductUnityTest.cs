using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class ProductUnityTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateCategory_WithValidParametersState()
        {
            Action action= () => new Product("TestNameExample", "TestDescriptionExample", 1.00M, 1, "TestImageExample.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid Id State")]
        public void CreateCategory_WithValidIdParametersState()
        {
            Action action = () => new Product(5, "TestNameExample", "TestDescriptionExample", 2.00M, 2, "TestImageExample.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos

        [Fact(DisplayName = "Create Product With Invalid Id State")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionIdInvalid()
        {
            Action action = () => new Product(-1, "TestNameExample", "TestDescriptionExample", 1.00M, 1, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "TestDescriptionExample", 2.00M, 2, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Minimum State Name")]
        public void CreateProduct_WithInvalidMinimumParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "hh", "TestDescriptionExample", 3.00M, 3, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Maximum State Name")]
        public void CreateProduct_WithInvalidMaximumParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "nolannolannolannolannolannolan" +
                "nolannolannolannolannolannolan" +
                "nolannolannolannolannolannolannolannolan" +
                "nolannolannolannolan", "TestDescriptionExample", 4.00M, 4, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "TestNameExample", null, 5.00M, 5, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Minimum State Description")]
        public void CreateProduct_WithInvalidMinimumParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "TestNameExample", "inva", 5.00M, 5, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minumum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Maximum State Description")]
        public void CreateProduct_WithInvalidMaximumParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "TestNameExample", "invaliddiinvaliddiinvaliddi" +
                "invaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddi" +
                "invaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddi" +
                "invaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddiinvaliddi", 5.00M, 5, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too long, maximum 200 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreatProduct_WithInvalidPriceParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "TestNameExample", "TestDescriptionExample", -5.00M, 5, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreatProduct_WithInvalidStockParameters_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "TestNameExample", "TestDescriptionExample", 5.00M, -5, "TestImageExample");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Null State Image")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "TestNameExample", "TestDescriptionExample", 5.00M, 5, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, image is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Minimum State Image")]
        public void CreateProduct_WithInvalidMinimumParameters_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "TestNameExample", "TestDescriptionExample", 5.00M, 5, "e");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, too short, minumum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Maximum State Image")]
        public void CreateProduct_WithInvalidMaximumParameters_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "TestNameExample", "TestDescriptionExample", 5.00M, 5, "imageimageimageimage" +
                "imageimageimageimageimageimageimageimageimageimageimageimageimageimageimageimage" +
                "imageimageimageimageimageimageimageimageimageimageimageimageimageimageimageimage" +
                "imageimageimageimageimageimageimageimageimageimageimageimageimageimageimageimage");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, too long, maximum 200 characters.");
        }
        #endregion
    }
}
