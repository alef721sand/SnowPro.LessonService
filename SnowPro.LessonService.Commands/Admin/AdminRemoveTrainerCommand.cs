using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminRemoveTrainerCommand(IAdmin admin, ILesson lesson) : ICommand
    {
        public void Execute()
        {
            admin.RemoveTrainer(lesson);
        }
    }
}
