﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hovedopgave1.Models;

namespace Hovedopgave1.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Students> Students { get; }

        void OpretStudent(Students students);

        Students SletStudent(int studentid);

        void RedigerStudent(Students students);

        List<Students> SøgStudentPåNavn(string navn);

        List<Students> SøgPåStudentUddannelse(string uddannelse);
    }
}
