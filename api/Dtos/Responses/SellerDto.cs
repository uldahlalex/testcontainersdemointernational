using dataaccess;

namespace api.Dtos;


    public class SellerDto 
    {
        public SellerDto(Seller entity)
        {
            Id = entity.Id;
            Description = entity.Description;
            Name = entity.Name;
            Pets = entity.Pets.Select(p => new PetDto(p)).ToList();
        }
        
        public string Id { get; set; } = null!;
    
        public string Name { get; set; } = null!;
    
        public string Description { get; set; } = null!;
    
        public virtual ICollection<PetDto> Pets { get; set; } = new List<PetDto>();
    }
