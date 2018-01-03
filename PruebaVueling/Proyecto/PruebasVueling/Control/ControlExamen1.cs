using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Configuration;
using log4net;

namespace Control
{
    public interface IControlExamen1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        string Prueba(int num);
        string Cadena(int numEmpezar);
        bool DivisbleTres(int numero);
        bool DivisbleCinco(int numero);
    }
    public class ControlExamen1 : IControlExamen1
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ControlExamen1));

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string Prueba(int num)
        {
            
            string respuesta = "";
            try
            {
            logger.Debug("Start metod: Prueba");
            respuesta= Cadena(num);
            WriteDocumento(respuesta);
            logger.Debug("End metod: Prueba");
            }
            catch (ArgumentNullException)
            {
                logger.Error("Valor Nullo");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return respuesta;

        }

        public string Cadena(int numEmpezar)
        {
            logger.Debug("Start metod: Cadena");
            string cadena = "";
            try { 
                for (int i = numEmpezar; i < int.Parse(ConfigurationManager.AppSettings["MaxLenght"]); i++)
                {
                    if (DivisbleTres(i) || DivisbleCinco(i))
                    {
                        if (DivisbleTres(i))
                        {
                            cadena = cadena + "Fizz";
                        }
                        if (DivisbleCinco(i))
                        {
                            cadena = cadena + "Buzz";
                        }
                        cadena = cadena + ",";
                    }
                    else
                    {
                        cadena = cadena + i + ",";
                    }
                }
            }catch (ArgumentNullException)
            {
                logger.Error("Valor Nullo");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            
            logger.Debug("End metod: Cadena");
            return cadena;
        }

        public bool DivisbleTres(int numero)
        {
            return numero % 3 == 0;
        }
        public bool DivisbleCinco(int numero)
        {
            return numero % 5 == 0;
        }
        private void WriteDocumento(String Cadena)
        {
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(ConfigurationManager.AppSettings["PathDoc"], true))
            {
                file.WriteLine(Cadena + " - " + DateTime.Now);
            }
            

        }


    }


}
