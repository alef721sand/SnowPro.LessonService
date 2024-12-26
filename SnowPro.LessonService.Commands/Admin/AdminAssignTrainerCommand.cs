using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminAssignTrainerCommand(IAdmin admin, ILesson lesson, ITrainer trainer) : ICommand
    {
        public void Execute()
        {
            admin.AssignTrainer(lesson, trainer);
        }
    }
}
