using EduHub.Ch02.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Repositories
{
    public interface IClubRepository
    {
        IReadOnlyList<Club> GetAll();
        Club? GetById(Guid id);
        void Add(Club club);
    }
}
