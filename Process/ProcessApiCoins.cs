using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Data;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Process
{
    public class ProcessApiCoins
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public ProcessApiCoins()
        {
        }
        public ProcessApiCoins(bool result, string msg)
        {
            this.Result = result;
            this.Message = msg;

        }
        internal ProcessApiCoins AddList(CoinContext context, List<Coins> model)
        {
            try
            {
                ProcessApiCoins proc = new ProcessApiCoins(true, "Sucess ;)");
                context.Set<Coins>().AddRange(model);
                return proc;
            }
            catch
            {
                return new ProcessApiCoins(false, "Fail to import");
            }
        }
        public string GetItemFila(CoinContext context)
        {
            try
            {
                if (context.Coins?.Any() == true)
                {
                    var lastCoin = context.Coins.Last();
                    context.Coins.Remove(lastCoin);
                    context.SaveChanges();
                    return JsonConvert.SerializeObject(lastCoin, Formatting.Indented).ToString();
                }
                return JsonConvert.SerializeObject(new Coins() { Id = -1, Message = "Sorry, no more coins here." });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new Coins() { Id = -1, Message = ex.Message.ToString() });
            }
        }
    }


}
