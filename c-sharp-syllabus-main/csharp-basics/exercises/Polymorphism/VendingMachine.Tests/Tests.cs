using AutoFixture;
using AutoFixture.AutoMoq;

namespace VendingMachine.Tests;

[TestFixture]
public class Tests
{
    private IFixture _fixture;
    private VendingMachine _vendingMachine;

    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _vendingMachine = new VendingMachine("Test", false, new Money(0, 0));
    }

    [Test]
    public void VendingMachine_ReturnVariables_ShouldReturnCorrectValues()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_vendingMachine.Manufacturer, Is.EqualTo("Test"));
            Assert.That(_vendingMachine.HasProducts, Is.EqualTo(false));
            Assert.That(_vendingMachine.Amount, Is.EqualTo(new Money(0, 0)));
        });
    }
    
    [Test]
    public void InsertCoin_WithValidCoinType_ShouldAddAmountToVendingMachine()
    {
        var amount = new Money(1, 0);
        var newAmount = _vendingMachine.InsertCoin(amount);
        Assert.That(newAmount, Is.EqualTo(_vendingMachine.Amount));
    }

    [Test]
    public void InsertCoin_WithInvalidCoinType_ShouldThrowVendingMachineExceptions()
    {
        var amount = new Money(5, 0);
        Assert.Throws<VendingMachineExceptions>(() => _vendingMachine.InsertCoin(amount));
    }

    [Test]
    public void ReturnMoney_ShouldReturnLastMoneyInputAndResetLastMoneyInputAndAmount()
    {
        var startAmount = _vendingMachine.Amount;
        var amount = new Money(1, 0);
        _vendingMachine.InsertCoin(amount);
        var returnedMoney = _vendingMachine.ReturnMoney();
        Assert.Multiple(() =>
        {
            Assert.That(returnedMoney.Euros, Is.EqualTo(1));
            Assert.That(returnedMoney.Cents, Is.EqualTo(0));
            Assert.That(_vendingMachine.Amount.Euros, Is.EqualTo(startAmount.Euros));
            Assert.That(_vendingMachine.Amount.Cents, Is.EqualTo(startAmount.Cents));
        });
    }

    [Test]
    public void AddProduct_WithAvailableNumber_ShouldAddProductToProductsArray()
    {
        var name = "Test Product";
        var price = new Money(1, 50);
        var count = 10;
        var result = _vendingMachine.AddProduct(name, price, count);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(_vendingMachine.Products[0].Name, Is.EqualTo(name));
            Assert.That(_vendingMachine.Products[0].Price, Is.EqualTo(price));
            Assert.That(_vendingMachine.Products[0].Available, Is.EqualTo(count));
        });
    }

    [Test]
    public void AddProduct_WithNoAvailableNumber_ShouldThrowVendingMachineExceptions()
    {
        for (var i = 0; i < 49; i++)
        {
            _vendingMachine.AddProduct("Test Product", new Money(1, 50), 10);
        }

        var name = "Test Product";
        var price = new Money(1, 50);
        var count = 10;

        Assert.Throws<VendingMachineExceptions>(() => _vendingMachine.AddProduct(name, price, count));
    }

    [Test]
    public void UpdateProduct_WithExistingProductNumber_ShouldUpdateProductInformation()
    {
        _vendingMachine.AddProduct("Test Product", new Money(2, 50), 5);
        var expectedProduct = new Product(3, new Money(3, 0), "Updated Test Product", 0);
        _vendingMachine.UpdateProduct(0, "Updated Test Product", new Money(3, 0), 3);
        var productAsIs = _vendingMachine.Products[0];
        Assert.Multiple(() =>
        {
            Assert.That(productAsIs.Available, Is.EqualTo(expectedProduct.Available));
            Assert.That(productAsIs.Price.Euros, Is.EqualTo(expectedProduct.Price.Euros));
            Assert.That(productAsIs.Name, Is.EqualTo(expectedProduct.Name));
            Assert.That(productAsIs.ProductNumber, Is.EqualTo(expectedProduct.ProductNumber));
        });
    }

    [Test]
    public void UpdateProduct_WithNonExistingProductNumber_ShouldThrowException()
    {
        var vendingMachine = new VendingMachine("Test Manufacturer", true, new Money(10, 0));

        Assert.Throws<VendingMachineExceptions>(() =>
            vendingMachine.UpdateProduct(51, "Test Product", new Money(2, 50), 5));
    }

    [Test]
    public void BuyProduct_WithAvailableProductAndEnoughMoney_ShouldDecreaseProductCountAndReturnProduct()
    {
        var vendingMachine = new VendingMachine("Test Manufacturer", true, new Money(10, 0));
        vendingMachine.AddProduct("Test Product", new Money(2, 50), 5);
        vendingMachine.InsertCoin(new Money(2, 0));
        vendingMachine.InsertCoin(new Money(0, 50));
        var boughtProduct = vendingMachine.BuyProduct("Test Product");

        Assert.That(boughtProduct.Available, Is.EqualTo(4));
    }

    [Test]
    public void BuyProduct_WithUnavailableProduct_ShouldThrowException()
    {
        var vendingMachine = new VendingMachine("Test Manufacturer", true, new Money(10, 0));
        vendingMachine.AddProduct("Test Product", new Money(2, 50), 0);
        vendingMachine.InsertCoin(new Money(2, 0));

        Assert.Throws<VendingMachineExceptions>(() => vendingMachine.BuyProduct("Test Product"));
    }

    [Test]
    public void BuyProduct_WithNotEnoughMoney_ShouldThrowException()
    {
        var vendingMachine = new VendingMachine("Test Manufacturer", true, new Money(10, 0));
        vendingMachine.AddProduct("Test Product", new Money(2, 50), 5);
        vendingMachine.InsertCoin(new Money(1, 0));

        Assert.Throws<VendingMachineExceptions>(() => vendingMachine.BuyProduct("Test Product"));
    }
    
    [Test]
    public void BuyProduct_WithMoreMoneyThanShouldBe_ShouldDecreaseProductCountAndReturnProduct()
    {
        var vendingMachine = new VendingMachine("Test Manufacturer", true, new Money(10, 0));
        vendingMachine.AddProduct("Test Product", new Money(2, 50), 5);
        vendingMachine.InsertCoin(new Money(2, 0));
        vendingMachine.InsertCoin(new Money(2, 0));
        var boughtProduct = vendingMachine.BuyProduct("Test Product");

        Assert.That(boughtProduct.Available, Is.EqualTo(4));
    }

    [Test]
    public void AddMoney_CentsIsMoreThan100_ShouldIncreaseEuroAndDecreaseCents()
    {
        var money = new Money(0, 50);
        var newMoney = money.Add(new Money(0, 70));
        Assert.Multiple(() =>
        {
            Assert.That(newMoney.Euros, Is.EqualTo(1));
            Assert.That(newMoney.Cents, Is.EqualTo(20));
        });
    }
}