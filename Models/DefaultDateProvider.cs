using Egzamin2024.Interfaces;
using Egzamin2024.Models;
using System;
/*Mikołaj Handzlik 14273*/
namespace Egzamin2024.Services
{
    public class DefaultDateProvider : IDateProvider
    {
        public DateTime CurrentDate => DateTime.Now;
    }
}
