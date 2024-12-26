using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminEnrollCommand(IAdmin admin, ILesson lesson, IStudent student) : ICommand
    {
        public void Execute()
        {
            admin.Enroll(lesson, student);
        }
    }
}
