using SnowPro.LessonService.Core.Base;

namespace SnowPro.LessonService.Core.Interfaces
{
    public interface ILesson
    {
        void EnrollStudent(IStudent? student);
        void UnEnrollStudent(IStudent? student);
        void AssignTrainer(ITrainer? trainer);
        void RemoveTrainer();
        void Reschedule(DateTime dateFrom, int duration);
        void CancelLesson();
        void CompleteLesson();
        void StartLesson();
        void SetName(string value);
        void SetDescription(string value);
        void SetTrainingLevel(TrainingLevel value);
        void SetLessonType(LessonType value);
        void SetMaxStudents(int value);
        string GetName();
        string GetDescription();
        TrainingLevel GetTrainingLevel();
        LessonType GetLessonType();
        int GetMaxStudents();
    }
}
