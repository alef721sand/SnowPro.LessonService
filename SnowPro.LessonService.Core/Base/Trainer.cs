using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Core.Base
{
    public class Trainer(Guid id) : Person(id), ITrainer
    {
        public void CompleteLesson(ILesson? lesson)
        {
            if (lesson == null)
                throw new InvalidOperationException("Cannot Complete Lesson. Lesson is not defined.");
            lesson.CompleteLesson();
        }
        public void CancelLesson(ILesson? lesson)
        {
            if (lesson == null)
                throw new InvalidOperationException("Cannot Cancel Lesson. Lesson is not defined.");
            lesson.CancelLesson();
        }
        public void StartLesson(ILesson? lesson)
        {
            if (lesson == null)
                throw new InvalidOperationException("Cannot Start Lesson. Lesson is not defined.");
            lesson.StartLesson();
        }
    }
}
