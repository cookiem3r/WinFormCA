
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WinFromCA.Application.Interfaces;

namespace WinFromCA.Application.CommonContext.Queries.GetTodayDate
{
    public class GetTodayDateHandler : IRequestHandler<GetTodayDateQuery, DateTime>
    {
        private readonly IDateTimeService _dateTimeService;
        public GetTodayDateHandler(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public Task<DateTime> Handle(GetTodayDateQuery request, CancellationToken cancellationToken)
        {
            Task<DateTime> atask = new Task<DateTime>(() => {
                return _dateTimeService.GetTodayDate(); 
            });
            atask.Start();
           
            return atask;
        }
    }
}
