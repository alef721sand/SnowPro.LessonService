using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminUnEnrollCommand(IAdmin admin, ILesson lesson, IStudent student) : ICommand
    {
        public void Execute()
        {
            admin.UnEnroll(lesson, student);
        }
    }
}
