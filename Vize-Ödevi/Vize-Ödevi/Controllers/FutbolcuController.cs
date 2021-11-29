using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vize_Ödevi.Controllers
{
    public class FutbolcuController : Controller
    {
        public IActionResult Listele()
        {
            return View(Models.FutbolcuVeri.Futbolcular);
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Yeni(Models.Futbolcu yeniFutbolcu)
        {
            Models.FutbolcuVeri.Futbolcular.Add(yeniFutbolcu);
            return RedirectToAction("Listele");

        }

        public IActionResult Guncelle(int id)
        {
            var r = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == id);
            return View(r);

        }

        [HttpPost]

        public IActionResult Guncelle(Models.Futbolcu FutbolcuGuncelle)
        {
            var c = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == FutbolcuGuncelle.Id);
            var r = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == FutbolcuGuncelle.Id);
            r.Ad = FutbolcuGuncelle.Ad;
            r.Soyad = FutbolcuGuncelle.Soyad;
            r.Uyruk = FutbolcuGuncelle.Uyruk;
            r.Mevki = FutbolcuGuncelle.Mevki;
            r.Boy = FutbolcuGuncelle.Boy;

            Models.FutbolcuVeri.Futbolcular.Remove(c);
            Models.FutbolcuVeri.Futbolcular.Add(r);

            return RedirectToAction("Listele");
        }


        public IActionResult Detay(int id)
        {
            var r = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == id);
            return View(r);
        }



        public IActionResult Sil(int id)
        {
            var r = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == id);
            return View(r);

        }

        [HttpPost]

        public IActionResult Sil(Models.Futbolcu futbolcu)
        {
            var r = Models.FutbolcuVeri.Futbolcular.FirstOrDefault(x => x.Id == futbolcu.Id);
            Models.FutbolcuVeri.Futbolcular.Remove(r);
            return RedirectToAction("Listele");

        }
    }
}
