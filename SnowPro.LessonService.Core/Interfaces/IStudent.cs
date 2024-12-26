namespace SnowPro.LessonService.Core.Interfaces;

public interface IStudent
{
    void Enroll(ILesson? lesson);
    void UnEnroll(ILesson? lesson);


}