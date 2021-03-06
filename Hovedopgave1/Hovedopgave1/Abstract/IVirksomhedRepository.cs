﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Models;

namespace Hovedopgave1.Abstract
{
    public interface IVirksomhedRepository
    {
        IEnumerable<Virksomhed> Virksomhed { get; }

        void OpretVirksomhed(Virksomhed virksomhed);

        void RedigerVirksomhed(Virksomhed virksomhed);
        Virksomhed SletVirksomhed(int id);

        List<Virksomhed> SøgVirksomhedPåNavn(string navn);

        List<Virksomhed> SøgVirksomhedPåMuligeOpgaver(string opgave);

        List<Virksomhed> SøgVirksomhedPåProfiler(string profiler);

        List<Virksomhed> SøgVirksomhedPåStyrkeposition(string position);

        List<Virksomhed> SøgVirksomhedPåOpgaverOgPosition(string opgave, string position);

        List<Virksomhed> SøgVirksomhedPåProfilerOgPosition(string profiler, string position);

        List<Virksomhed> SøgVirksomhedPåOpgaverOgProfiler(string opgave, string profiler);

        List<Virksomhed> SøgVirksomhedPåOpgaverOgProfilerOgPosition(string opgave, string profiler, string position);

        List<Virksomhed> SøgVirksomhedPåAlt(string navn, string opgave, string profiler, string position);
    }
}