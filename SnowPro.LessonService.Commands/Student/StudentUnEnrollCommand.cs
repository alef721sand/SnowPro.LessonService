using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Student
{
    public class StudentUnEnrollCommand(ILesson lesson, IStudent student) : ICommand
    {
        public void Execute()
        {
            student.UnEnroll(lesson);
        }
    }
}
