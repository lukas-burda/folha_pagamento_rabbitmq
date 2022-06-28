using ISSDecontoB.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSDecontoB.Interfaces
{
    public interface IRabbitMQServices
    {
        public List<Folha> ConsumirQueue();
    }
}
