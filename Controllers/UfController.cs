using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class UfController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post([FromForm] double UF)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://api.gael.cloud/general/public/monedas/UF");
        string json = await response.Content.ReadAsStringAsync();
        dynamic data = JsonConvert.DeserializeObject(json);
        string valorString = data.Valor;
        int valor = int.Parse(valorString.Split(',')[0]);
        double resultadod = valor * UF;
        int resultado = Convert.ToInt32(resultadod);
        //return Ok(resultadod);
        return Ok(new { valorEnpesos = "$ "+resultado.ToString("n0")});
    }
}