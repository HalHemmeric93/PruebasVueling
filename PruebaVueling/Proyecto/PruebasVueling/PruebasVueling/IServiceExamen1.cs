using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PruebasVueling
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceExamen1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceExamen1
    {
        [OperationContract]
        string DoWork(int num);
    }
}
