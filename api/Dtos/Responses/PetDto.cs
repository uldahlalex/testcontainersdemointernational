using api.Dtos;
using dataaccess;

public class PetDto
{

    public PetDto(Pet entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Breed = entity.Breed;
        Createdat = entity.Createdat;
        SoldDate = entity.SoldDate;
        Price = entity.Price;
        Seller = entity.Seller;
        
    }
    
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public DateTime Createdat { get; set; }

    public DateOnly? SoldDate { get; set; }

    public decimal Price { get; set; }

    public string Seller { get; set; } = null!;

}