using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.Ports 
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
