using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminRescheduleCommand(IAdmin admin, ILesson lesson, DateTime dateFrom, int durtion) : ICommand
    {
        public void Execute()
        {
            admin.Reschedule(lesson, dateFrom, durtion);
        }
    }
}
