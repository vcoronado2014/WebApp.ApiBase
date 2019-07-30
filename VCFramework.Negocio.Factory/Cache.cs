using System;
using System.Collections.Generic;
using System.Text;

namespace VCFramework.Negocio.Factory
{
    public class Cache
    {
        public static string NombreCache { get; set; }


        /// <summary>
        /// 5 segundos
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Minimo()
        {
            return DateTimeOffset.Now.AddSeconds(5);
        }

        /// <summary>
        /// 30 segundos
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Temporal()
        {
            return DateTimeOffset.Now.AddSeconds(30);
        }
        /// <summary>
        /// 10 minutos
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Suave()
        {
            return DateTimeOffset.Now.AddMinutes(10);
        }
        /// <summary>
        /// 1 hora
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Medio()
        {
            return DateTimeOffset.Now.AddHours(1);
        }
        /// <summary>
        /// 3 horas
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Fuerte()
        {
            return DateTimeOffset.Now.AddHours(3);
        }

        /// <summary>
        /// 12 horas
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset ExtraFuerte()
        {
            return DateTimeOffset.Now.AddHours(12);
        }
        /// <summary>
        /// 1 día
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Diario()
        {
            return DateTimeOffset.Now.AddDays(1);
        }
        /// <summary>
        /// 7 dias
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Semanal()
        {
            return DateTimeOffset.Now.AddDays(7);
        }
        /// <summary>
        /// 1 mes
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Mensual()
        {
            return DateTimeOffset.Now.AddMonths(1);
        }
        /// <summary>
        /// 3 meses
        /// </summary>
        /// <returns></returns>
        public static DateTimeOffset Maximo()
        {
            return DateTimeOffset.Now.AddMonths(3);
        }
    }
}
