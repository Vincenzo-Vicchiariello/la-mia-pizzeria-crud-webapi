using LaMiaPizzeriaNuova.DataBase;
using LaMiaPizzeriaNuova.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{Name}")]
        public IActionResult SearchByName(string name)
        {
            using (PizzaContext context = new PizzaContext())
            {
                PizzaModel? pizzaName = context.Pizze.Where(pizza => pizza.Name.Contains("name")).FirstOrDefault();
                if (pizzaName != null)
                {
                    return Ok(pizzaName);
                }
                else return NotFound("Questa pizza non esiste");
            }

        }

    }
}
