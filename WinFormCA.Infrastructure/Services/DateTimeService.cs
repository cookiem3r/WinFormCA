using System;
using WinFromCA.Application.Interface;

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
