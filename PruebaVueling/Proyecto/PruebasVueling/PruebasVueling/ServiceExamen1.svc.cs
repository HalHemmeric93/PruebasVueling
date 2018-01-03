using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleInjector;
using Control;
namespace PruebasVueling
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceExamen1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceExamen1.svc o ServiceExamen1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceExamen1 : IServiceExamen1
    {
        static readonly Container container;
        static ServiceExamen1()
        {
            container = new Container();
            container.Register<IControlExamen1, ControlExamen1>();
            container.Verify();
        }
        public string DoWork(int num)
        {
            var control = container.GetInstance<IControlExamen1>();

            return control.Prueba(num);
        }
    }
}
