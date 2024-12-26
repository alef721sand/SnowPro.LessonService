using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminCreateLessonCommand(IAdmin admin, string name,
        string description,
        DateTime dateFrom,
        int duration,
        TrainingLevel trainingLevel,
        LessonType lessonType,
        int maxStudents) : ICommand
    {
        public void Execute()
        {
            admin.CreateLesson(name,description,dateFrom,duration,trainingLevel,lessonType,maxStudents);
        }
    }
}
