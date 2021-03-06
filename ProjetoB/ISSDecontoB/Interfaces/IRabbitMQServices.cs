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
        public double TotalFolhas(List<Folha> folhas);
        public double MediaFolhas(List<Folha> folhas);
    }
}
