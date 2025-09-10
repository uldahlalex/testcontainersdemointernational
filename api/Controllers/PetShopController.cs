using api.Dtos;
using dataaccess;
using Microsoft.AspNetCore.Mvc;

namespace api;

public class PetShopController(PetService petService) : ControllerBase
{

    [HttpPost(nameof(CreateSellerWithAPetAndReturn))]
    public SellerDto CreateSellerWithAPetAndReturn([FromBody]CreateSellerDto dto)
    {
        var result = petService.CreateSellerWithPet(dto);
       return result;
    }
    
}