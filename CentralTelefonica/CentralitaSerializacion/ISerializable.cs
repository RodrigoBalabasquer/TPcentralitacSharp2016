﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    public interface ISerializable
    {
        string RutaDeArchivo 
        {
            get;
            set;
        }
        bool Deserializarse();
        bool Serializarse();
    }
}
