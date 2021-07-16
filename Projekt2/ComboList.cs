using System.Collections.Generic;
using System.Linq;

namespace Projekt2
{
    class ComboList
    {
        public static IEnumerable<string> ListOrderNames()
        {
            return DataBaseService.OrderType().Select(x => x.NazwaRodzajZlecenia);
        }

        public static List<string> ListOrderNamesAdditional()
        {
            List<string> lista = new List<string>(DataBaseService.OrderType().Select(x => x.NazwaRodzajZlecenia));
            lista.Add("Wszystkie");
            return lista;
        }

        public static IEnumerable<string> ListStatNames()
        {
            return DataBaseService.OrderStat().Select(x => x.StatusZlecenia);
        }

        public static List<string> ListStatNamesAdditional()
        {
            List<string> lista = new List<string>(DataBaseService.OrderStat().Select(x => x.StatusZlecenia));
            lista.Add("Wszystkie");
            return lista;
        }
    }
}
