using Fr.EQL.Ai109.Totapatt.Business;
using Fr.EQL.Ai109.Totapatt.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.WebApplication.Controllers
{
    public class RechercheController : Controller
    {
        // GET: TerrainController
        // prend un id utilisateur
        [Route("Rechercher/ChoisirTerrain/{idUtilisateur:int}")]
        public ActionResult ChoisirTerrain(int id)
        {
            TerrainBU bu = new();
            List<Terrain> mesTerrains = bu.GetByIdUtilisateur(id);
            return View(mesTerrains);
        }

        // porend id terrain
        [Route("Rechercher/ChoisirOffre/{id:int}")]
        public ActionResult ChoisirOffre(int id)
        {
            TerrainBU bu = new();
            Terrain t = bu.GetTerrain(id);

            List<OffreDeTonte> offres = new();

            
            return View();
        }
        // GET: TerrainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TerrainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TerrainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TerrainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TerrainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TerrainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TerrainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
