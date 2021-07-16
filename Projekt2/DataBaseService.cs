using Microsoft.EntityFrameworkCore;
using Projekt2.ScaffoldModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt2
{
    class DataBaseService
    {

        public static IEnumerable<Zlecenium> AllOrders()
        {
            using var db = new HZPContext();
            return db.Zlecenia.Include(x => x.IdRodzajZleceniaNavigation).ToList();            
        }

        public static IEnumerable<RodzajZlecenium> OrderType()
        {
            using var db = new HZPContext();
            return db.RodzajZlecenia.ToList();
        }

        public static IEnumerable<StatusZlecenium> OrderStat()
        {
            using var db = new HZPContext();
            return db.StatusZlecenia.ToList();
        }

        public static IEnumerable<SurowcePółprodukty> RawMaterials()
        {
            using var db = new HZPContext();
            return db.SurowcePółprodukties.ToList();
        }

        public static void AddOrder(Zlecenium order)
        {
            using var db = new HZPContext();
            db.Zlecenia.Add(order);
            db.SaveChanges();
        }


        public static void DeleteOrder(Zlecenium selectedItem)
        {
            using var db = new HZPContext();
            db.Zlecenia.Remove(db.Zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia));
            db.SaveChanges();
        }

        public static void ChangeOrderStat(Zlecenium selectedItem, int stat)
        {
            using var db = new HZPContext();
            var zlecenia = db.Zlecenia.ToList();

            if (stat == 3)
            {
                zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia).IdStatusu = stat;
                zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia).NieprzekraczalnyTerminWykonania = DateTime.Now;
                zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia).RzeczywistaDataZakonczenia = DateTime.Now;
                db.Zlecenia.Update(zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia));
                db.SaveChanges();
            }
            else
            {
                zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia).IdStatusu = stat;
                db.Zlecenia.Update(zlecenia.Single(x => x.IdZlecenia == selectedItem.IdZlecenia));
                db.SaveChanges();
            }

           
        }

        public static IEnumerable<Zlecenium> OrdersSelectedByDate(DateTime start, DateTime end)
        {
            using var db = new HZPContext();
            var zlecenia = db.Zlecenia.Include(x => x.IdRodzajZleceniaNavigation).ToList();
            return zlecenia.Where(x => x.DataPrzyjecia >= start && x.DataPrzyjecia <= end);
        }

        public static int RequireDaysForOrder(string NameOfIdRz)
        {
            using var db = new HZPContext();
            var rodzajZlecenia = db.RodzajZlecenia.ToList();
            return rodzajZlecenia.Where(x => x.NazwaRodzajZlecenia == NameOfIdRz).Select(x => x.PotrzebnyCzasNaRealizacje).LastOrDefault();
        }
    }
}
