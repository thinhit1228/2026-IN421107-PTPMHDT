using EduHub.Ch02.Patterns.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Services
{
    public interface IReportService
    {
        string Generate(IReportStrategy strategy);
    }
}
