using SnowPro.LessonService.Core.Base;

namespace SnowPro.LessonService.Core.Interfaces
{
    public interface IAdmin
    {
        ILesson CreateLesson(string name,
            string description,
            DateTime dateFrom,
            int duration,
            TrainingLevel trainingLevel,
            LessonType lessonType,
            int maxStudents);
        void Enroll(ILesson lesson, IStudent student);
        void RemoveTrainer(ILesson lesson);
        void UnEnroll(ILesson lesson, IStudent student);
        void Reschedule(ILesson? lesson, DateTime dateFrom, int duration);
        void AssignTrainer(ILesson? lesson, ITrainer? trainer);
        void SetName(ILesson lesson, string name);
        void SetDescription(ILesson lesson, string description);
        void SetTrainingLevel(ILesson lesson, TrainingLevel trainingLevel);
        void SetLessonType(ILesson lesson, LessonType lessonType);
        void SetMaxStudents(ILesson lesson, int maxStudents);
        string GetName(ILesson lesson);
        string GetDescription(ILesson lesson);
        TrainingLevel GetTrainingLevel(ILesson lesson);
        LessonType GetLessonType(ILesson lesson);
        int GetMaxStudents(ILesson lesson);
    }

}
