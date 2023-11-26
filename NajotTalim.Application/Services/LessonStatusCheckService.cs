using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NajotTalim.Application.Abstractions;

namespace NajotTalim.Application.Services
{
    public class LessonStatusCheckService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public LessonStatusCheckService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
             while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

                var lessons = await context.Lessons
                    .Include(x => x.Attendances)
                    .Where(x => x.EndDateTime.Date == DateTime.Now.Date
                    && x.EndDateTime < DateTime.Now)
                    .ToListAsync(stoppingToken);

                foreach (var lesson in lessons)
                {
                    lesson.IsDone = lesson.Attendances.Any();

                    context.Lessons.Add(lesson);
                }

                await context.SaveChangesAsync(stoppingToken);
            }
        }
    }
}
