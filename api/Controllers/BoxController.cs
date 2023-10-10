using service;
using infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[ApiController]
public class BoxController : ControllerBase
{
    private readonly Service _service;

    public BoxController(Service service)
    {
        _service = service;
    }
    
    [Route("api/boxes")]
    [HttpPost]
    public Box CreateBox([FromBody] Box box)
    {
    
        return _service.CreateBox(box);
    }
  
    [Route("/api/boxes/{boxid}")]
    [HttpDelete]
    public bool DeleteBox([FromRoute] int boxid)
    {
        return _service.DeleteBox(boxid);
    }
  
    [Route("/api/boxes/{boxid}")]
    [HttpPut]
    public Box EditBox([FromBody] Box box)
    {
        return _service.EditBox(box);
    }
  
    [Route("/api/inventory")]
    [HttpGet]
    public IEnumerable<Box> GetAllBoxes()
    {
        return _service.GetAllBoxes();
    }
    [Route("/api/boxes/{boxid}")]
    [HttpGet]
    public Box GetBox([FromRoute]Box box)
    {
        return _service.GetBoxById(box.Id);
    }
    [Route("/api/inventory/search")]
    [HttpGet]
    public IEnumerable<Box> SearchForBoxes([FromQuery] string query)
    {
        return _service.SearchForBoxByName(query);
    }

}
