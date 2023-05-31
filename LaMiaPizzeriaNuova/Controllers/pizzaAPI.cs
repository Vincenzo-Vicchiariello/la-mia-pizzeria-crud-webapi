using LaMiaPizzeriaNuova.DataBase;
using LaMiaPizzeriaNuova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaNuova.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class pizzaAPI : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas()
        {
            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<PizzaModel> pizzas = context.Pizze;
                return Ok(pizzas.ToList());
            }


        }
        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            using (PizzaContext context = new PizzaContext())
            {
                PizzaModel? pizzaName = context.Pizze.Where(pizza => pizza.Name.Contains(name)).Include(pizza => pizza.PizzaCategory).FirstOrDefault();
                pizzaName.PizzaCategory.Pizze = new List<PizzaModel>();
                if (pizzaName != null)
                {
                    return Ok(pizzaName);
                }
                else return NotFound("Questa pizza non esiste");
            }

        }
        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            using (var db = new PizzaContext())
            {
                PizzaModel? pizzaIdToSearch = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaIdToSearch != null)
                {
                    return Ok(pizzaIdToSearch);
                }
                return NotFound();
            }
        }




    }
}
