namespace SnowPro.LessonService.Core.Interfaces;

public interface ITrainer
{
    void CompleteLesson(ILesson lesson);
    void CancelLesson(ILesson? lesson);
    void StartLesson(ILesson? lesson);

}