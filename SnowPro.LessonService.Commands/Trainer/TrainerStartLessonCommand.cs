using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Trainer
{
    public class TrainerStartLessonCommand(ITrainer trainer, ILesson lesson) : ICommand
    {
        public void Execute()
        {
            trainer.StartLesson(lesson);
        }
    }
}
