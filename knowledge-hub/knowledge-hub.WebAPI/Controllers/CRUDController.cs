using knowledge_hub.WebAPI.Intefraces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class CRUDController<T, TInsert, TUpdate>: ControllerBase
   {
      private readonly ICRUDService<T, TInsert,TUpdate> _crudService;
      public CRUDController(ICRUDService<T, TInsert, TUpdate> crudService) {
         _crudService = crudService;
      }

      [HttpGet]
      [Authorize]
      public virtual async Task<List<T>> Get(string? search) {
         return await _crudService.Get(search);
      }

      [HttpGet("{ID}")]
      [Authorize]
      public virtual async Task<T> GetById(int ID) {
         return await _crudService.GetById(ID, Request.Scheme + "//" + Request.Host);
      }

      [HttpPost]
      [Authorize]
      public async Task<T> Insert(TInsert insertRequest) {
         return await _crudService.Insert(insertRequest);
      }

      [HttpPut]
      [Authorize]
      public async Task<T> Update(int ID, TUpdate updateRequest) {
         return await _crudService.Update(ID, updateRequest);
      }

      [HttpDelete]
      [Authorize(Roles = "Admin")]
      public virtual async Task<bool> Delete(int ID) {
         return await _crudService.Delete(ID);
      }
   }
}
