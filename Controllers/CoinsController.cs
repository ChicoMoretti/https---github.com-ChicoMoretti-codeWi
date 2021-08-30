using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplicationAPI.Data;
using WebApplicationAPI.Models;
using WebApplicationAPI.Process;

namespace WebApplicationAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly ProcessApiCoins _processCoin = new ProcessApiCoins();
       [HttpPost]
        [Route("AddItemFila")]
        public string AddItemFila (
            [FromServices] CoinContext context, [FromBody] List<Coins> model)
        {
            if (ModelState.IsValid)
            {
                ProcessApiCoins proc = new ProcessApiCoins();
                proc.AddList(context, model);
                context.SaveChanges();
            }
            else
            {
                return "Sorry but your input is wrong, "+ BadRequest(ModelState).Value.ToString();
            }

            return "Sucess to add coins.";
        }

        [HttpGet]
        [Route("GetItemFila")]
        public string GetItemFila(
            [FromServices] CoinContext context)
        {
            return _processCoin.GetItemFila(context);
        }

       
    }





}
