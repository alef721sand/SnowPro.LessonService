using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Trainer
{
    public class TrainerCompleteLessonCommand(ITrainer trainer, ILesson lesson) : ICommand
    {
        public void Execute()
        {
            trainer.CompleteLesson(lesson);
        }
    }
}
