using NFLPlayers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFLPlayers.Controllers
{
    public class HomeController : Controller
    {
        private NFLEntities db = new NFLEntities();

        public ActionResult Index(string playerPosition, string searchstring)


        {
            var positionList = new List<string>();
            var PositionQuery = from posData in db.Players
                                orderby posData.Position
                                select posData.Position;

            positionList.AddRange(PositionQuery.Distinct());
            ViewBag.playerPosition = new SelectList(positionList); 

            var players = from m in db.Players
                          select m;

            players = players.Where(m => m.Status == true);

            //position search

            if (!string.IsNullOrEmpty(searchstring))

            {
                players = players.Where(m => m.Name.Contains(searchstring));
            }

            if (!string.IsNullOrEmpty(playerPosition))

            {
                players = players.Where(m => m.Position == playerPosition);
            }

            return View(players);
        }

        public ActionResult Add(int id = 0)
        {
            Player player = new Player();
            return View(player);
        }

        [HttpPost]

        public ActionResult Add(Player player)
        {

            if (player.ProfilePic == null)
            {

                player.ProfilePic = "https://i.pinimg.com/736x/0b/50/92/0b50924f40f2acda9a66dc8c21712f06--dallas-cowboys-pics-cowboys-football.jpg";
            }

            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        public new ActionResult Profile(int id)
        {

            Player player = db.Players.Find(id);
            return View(player);
        }


        public ActionResult Edit(int? id)

        {
            Player player = db.Players.Find(id);

            return View(player);

        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (player.ProfilePic == null)
            {

                player.ProfilePic = "https://i.pinimg.com/736x/0b/50/92/0b50924f40f2acda9a66dc8c21712f06--dallas-cowboys-pics-cowboys-football.jpg";
            }

            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        public ActionResult Delete(int? id)
        {
            Player player = db.Players.Find(id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //find the player again
            Player player = db.Players.Find(id);

            //delete from the database
            db.Players.Remove(player);

            db.SaveChanges();

            //return to the index page
            return RedirectToAction("Index");
        }

        public ActionResult Treatment()
        {

            var players = from m in db.Players
                          select m;

            players = players.Where(m => m.Status == false);

            return View(players);
        }
    }
}