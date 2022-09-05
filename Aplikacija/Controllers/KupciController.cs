using Aplikacija.App_Start;
using Aplikacija.Models;
using Aplikacija.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace Aplikacija.Controllers
{
    [Authorize]
    public class KupciController : ApiController //nasljeduje klasu ApiController
    {
        AdventureWorksOBPEntities dataBase = new AdventureWorksOBPEntities();

        public KupciController()
        {
            dataBase.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<KupacDto> GetKupci()
        {
            var kupci = dataBase.Kupacs;
            var kupciDto = AutoMapperConfig.Mapper.Map<IEnumerable<KupacDto>>(kupci);
            return kupciDto;
        }

        [HttpGet]
        [ResponseType(typeof(Kupac))]
        public IHttpActionResult GetKupac(int id)
        {
            var kupac = dataBase.Kupacs.Find(id);
            if (kupac == null)
                return NotFound();
            var kupacDto = AutoMapperConfig.Mapper.Map<KupacDto>(kupac);
            return Ok(kupacDto);
        }

        [HttpPost]
        [ResponseType(typeof(Kupac))]
        public IHttpActionResult CreateKupac(Kupac k)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            dataBase.Kupacs.Add(k);
            var kDto = AutoMapperConfig.Mapper.Map<KupacDto>(k);
            dataBase.SaveChanges();
            return Ok(kDto);
        }

       

        [HttpDelete]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeleteKupac(int id)
        {
            //nije uspijelo s entity

            //var kupac = dataBase.Kupacs.Find(id);
            //if (kupac == null)
            //    return NotFound();
            //var racuniKupca = Repo.GetRacuniKupca(id);
            //foreach (var racun in racuniKupca)
            //{
            //    var stavkeRacuna = racun.Stavkas.ToList();
            //    dataBase.Stavkas.RemoveRange(stavkeRacuna);
            //}
            //dataBase.Racuns.RemoveRange(racuniKupca);
            //dataBase.Kupacs.Remove(kupac);
            //dataBase.SaveChanges();
            //return Ok("Kupac uspješno obrisan");

            //uspijelo je s SQLHelperom
            var kupac = Repo.GetKupac(id);
            if (kupac == null)
                return NotFound();
            Repo.DeleteKupac(id);
            return Ok("Kupac uspješno obrisan");



        }
    }
}


