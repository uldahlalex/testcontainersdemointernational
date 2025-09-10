using System.ComponentModel.DataAnnotations;
using api;
using dataaccess;

namespace tests;

public class MyPetshopTests(PetService petService, MyDbContext ctx)
{
    //also sad path test
    [Fact]
    public void CreateSeller_ShouldThrowException_IfTheresAlreadySomeoneWithThatName()
    {
        //Arrange
        ctx.Sellers.Add(new Seller()
        {
            Description = "Bob",
            Name = "Bob",
            Id = Guid.NewGuid().ToString()
        });
        ctx.SaveChanges();

        var dto = new CreateSellerDto()
        {
            Description = "Bob",
            Name = "Bob"
        };
        
        //Act
        Assert.ThrowsAny<ValidationException>(() => petService.CreateSellerWithPet(dto));

    }
    
    //sad path test
    [Fact]
    public void CreateSeller_ShouldThrowExceptionWhenDataValidationFails()
    {
        Assert.Equal(0, ctx.Sellers.Count());
        
        
        //Arrange
        var dto = new CreateSellerDto()
        {
            Description = "",
            Name = ""
        };
        
        //Act + assert
        Assert.ThrowsAny<ValidationException>(() => petService.CreateSellerWithPet(dto));
        
     
    }
    
    //Happy path test
    [Fact]
    public void CreateSeller_ShouldSuccesfullyReturnSeller_AndInsertInDb()
    {
        Assert.Equal(0, ctx.Sellers.Count());
        
        
        //Arrange
        var dto = new CreateSellerDto()
        {
            Description = "Dlskjadsad",
            Name = "salkdjsajd"
        };
        
        //Act 
        var actual = petService.CreateSellerWithPet(dto);
        
        //Assert
        Assert.True(actual.Id.Length > 10);
        Assert.True(actual.Pets.Count == 1);
        Assert.True(actual.Pets.First().Id.Length > 10);
        Assert.Equal(1, ctx.Sellers.Count());
    }
}