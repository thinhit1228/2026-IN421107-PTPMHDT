using EduHub.Ch02.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Patterns.Observers
{
    public interface IEventObserver
    {
        void OnEventCreated(Event ev, Club club);

    }
}
