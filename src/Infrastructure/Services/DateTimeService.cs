using PearlsOfWisdom.Application.Common.Interfaces;
using System;

namespace PearlsOfWisdom.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
