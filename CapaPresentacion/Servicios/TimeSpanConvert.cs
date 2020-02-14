using System;
using System.Linq;

namespace CapaPresentacion
{
    public class TimeSpanConvert
    {
        public static TimeSpan StringToTimeSpan(string hora)
        {
            TimeSpan tiempo;
            int[] partes = hora.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            if (partes.Length == 2)
            {
                tiempo = new TimeSpan(partes[0], partes[1], 0);
            }
            else
            {
                tiempo = new TimeSpan(partes[0], partes[1], partes[2]);
            }
            return tiempo;
        }
    }
}
