using System;
using WinFromCA.Application.Interfaces;

namespace WinFormCA.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetTodayDate()
        {
            return DateTime.Now;
        }
    }
}
