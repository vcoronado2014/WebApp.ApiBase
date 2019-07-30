using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace VCFramework.Negocio.Factory
{
    public class Utiles
    {

        // Connection String
        //public const string ConnStr =
        //   "Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=bdcolegios_mysql;uid=root;pwd=co2008;option=3";
        //public const string ConnStr =
        //   "Driver={MySQL ODBC 5.1 Driver};Server=MYSQL5011.Smarterasp.net;Database=db_9dac90_cole;User=9dac90_cole;Password=antonia2006;Option=3;";

        public static string ConnStr()
        {
            string cns = "Driver={MySQL ODBC 5.1 Driver};Server=SQL5026.SmarterASP.NET;Database=DB_9DAC90_asambleas;User=DB_9DAC90_asambleas_admin;Password=antonia2006;Option=3;";
            if (System.Configuration.ConfigurationManager.ConnectionStrings["BDColegioSql"].ConnectionString != null)
                cns = System.Configuration.ConfigurationManager.ConnectionStrings["BDColegioSql"].ConnectionString;
            return cns;
        }

        public const string CNS = "BDColegioSql";

        public static string NombreBaseDatos()
        {
            string retorno = "'DB_9DAC90_asambleas'";

            if (System.Configuration.ConfigurationManager.AppSettings["NOMBRE_BD"] != null)
            {
                retorno = "'" + System.Configuration.ConfigurationManager.AppSettings["NOMBRE_BD"].ToString() + "'";
            }

            return retorno;
        }

        public static string ConstruyeFecha(DateTime fecha)
        {
            string retorno = "";
            string dia = "";
            string mes = "";
            string anno = "";
            string hora = "";
            string minutos = "";
            string segundos = "";


            if (fecha.Day < 10)
                dia = "0" + fecha.Day.ToString();
            else
                dia = fecha.Day.ToString();

            if (fecha.Month < 10)
                mes = "0" + fecha.Month.ToString();
            else
                mes = fecha.Month.ToString();

            if (fecha.Hour < 10)
                hora = "0" + fecha.Hour.ToString();
            else
                hora = fecha.Hour.ToString();

            if (fecha.Minute < 10)
                minutos = "0" + fecha.Minute.ToString();
            else
                minutos = fecha.Minute.ToString();

            if (fecha.Second < 10)
                segundos = "0" + fecha.Second.ToString();
            else
                segundos = fecha.Second.ToString();

            anno = fecha.Year.ToString();

            retorno = anno + "-" + mes + "-" + dia + " " + hora + ":" + segundos;
            return retorno;
        }
        public static void Log(string mensaje)
        {
            string carpetaArchivo = @"Logs\log.txt";
            string rutaFinal = AppDomain.CurrentDomain.BaseDirectory + carpetaArchivo;

            object Locker = new object();
            XmlDocument _doc = new XmlDocument();

            try
            {
                if (!File.Exists(rutaFinal))
                {
                    File.Create(rutaFinal);
                }

                _doc.Load(rutaFinal);

                lock (Locker)
                {
                    //var id = (XmlElement)_doc.DocumentElement.LastChild;
                    //id.GetElementsByTagName("Id");
                    int cantidad = _doc.ChildNodes.Count;
                    int indice = 1;
                    if (cantidad > 0)
                    {
                        //obtener el ultimo elemento id
                        if ((XmlElement)_doc.DocumentElement.LastChild != null)
                        {
                            var ultimo = (XmlElement)_doc.DocumentElement.LastChild;
                            indice = int.Parse(ultimo.LastChild.InnerText);
                            indice = indice + 1;
                        }
                    }

                    var el = (XmlElement)_doc.DocumentElement.AppendChild(_doc.CreateElement("error"));
                    //el.SetAttribute("Fecha", ConstruyeFecha(DateTime.Now));

                    el.AppendChild(_doc.CreateElement("Fecha")).InnerText = ConstruyeFecha(DateTime.Now);
                    el.AppendChild(_doc.CreateElement("Detalle")).InnerText = mensaje;
                    el.AppendChild(_doc.CreateElement("Id")).InnerText = indice.ToString();
                    _doc.Save(rutaFinal);
                }

            }
            catch (Exception ex)
            {

            }

        }

        public static string EntregaNombreId(string nombrePropiedad)
        {
            string retorno = "";
            StringBuilder sb = new StringBuilder();
            int contador = 0;
            if (nombrePropiedad != null && nombrePropiedad.Length > 0)
            {
                foreach (char s in nombrePropiedad.ToCharArray())
                {
                    sb.Append(s.ToString().ToUpper());
                    if (contador > 0)
                    {
                        if (Char.IsUpper(s))
                        {
                            sb.Insert(contador, "_");

                        }
                    }

                    contador++;
                }
            }
            if (sb.Length > 0)
                retorno = sb.ToString();
            return retorno;
        }
        public static void Log(Exception mensaje)
        {
            string carpetaArchivo = @"Logs\log.txt";
            string rutaFinal = AppDomain.CurrentDomain.BaseDirectory + carpetaArchivo;

            object Locker = new object();
            XmlDocument _doc = new XmlDocument();

            try
            {
                if (!File.Exists(rutaFinal))
                {
                    File.Create(rutaFinal);
                }

                _doc.Load(rutaFinal);

                lock (Locker)
                {
                    //var id = (XmlElement)_doc.DocumentElement.LastChild;
                    //id.GetElementsByTagName("Id");
                    int cantidad = _doc.ChildNodes.Count;
                    int indice = 1;
                    if (cantidad > 0)
                    {
                        //obtener el ultimo elemento id
                        if ((XmlElement)_doc.DocumentElement.LastChild != null)
                        {
                            var ultimo = (XmlElement)_doc.DocumentElement.LastChild;
                            indice = int.Parse(ultimo.LastChild.InnerText);
                            indice = indice + 1;
                        }
                    }

                    var el = (XmlElement)_doc.DocumentElement.AppendChild(_doc.CreateElement("error"));
                    //el.SetAttribute("Fecha", ConstruyeFecha(DateTime.Now));

                    el.AppendChild(_doc.CreateElement("Fecha")).InnerText = ConstruyeFecha(DateTime.Now);
                    el.AppendChild(_doc.CreateElement("Detalle")).InnerText = mensaje.Message;
                    el.AppendChild(_doc.CreateElement("Id")).InnerText = indice.ToString();
                    _doc.Save(rutaFinal);
                }

            }
            catch (Exception ex)
            {

            }


        }
        /// <summary>
        /// Validar Rut en el formato 12.333.666-K
        /// </summary>
        /// <param name="rut">Rut Formateado</param>
        /// <returns></returns>
        public static bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
