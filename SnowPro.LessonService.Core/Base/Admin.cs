using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Core.Base;

public class Admin(Guid id) : Trainer(id), IAdmin
{
    public ILesson CreateLesson(
        string name, 
        string description, 
        DateTime dateFrom, 
        int duration, 
        TrainingLevel trainingLevel, 
        LessonType lessonType, 
        int maxStudents)
    {
        return new Lesson(Guid.NewGuid(), 
            name, 
            description, 
            dateFrom, 
            duration, 
            trainingLevel, 
            lessonType,
            maxStudents);
    }
    
    public void Enroll(ILesson? lesson, IStudent? student)
    {
        if (lesson == null)
            throw new InvalidOperationException("Cannot enroll the student. Lesson is defined.");

        lesson.EnrollStudent(student);
    }

    public void UnEnroll(ILesson? lesson, IStudent? student)
    {
        if (lesson == null)
            throw new InvalidOperationException("Cannot unenroll the student. Lesson is defined.");

        lesson.UnEnrollStudent(student);
    }

    public void AssignTrainer(ILesson? lesson,ITrainer? trainer)
    {
        if (lesson == null)
            throw new InvalidOperationException("Cannot assign the trainer. Lesson is defined.");

        lesson.AssignTrainer(trainer);
    }

    public void SetName(ILesson lesson, string name)
    { 
        lesson.SetName(name);
    }

    public void SetDescription(ILesson lesson, string description)
    {
        lesson.SetDescription(description);
    }

    public void SetTrainingLevel(ILesson lesson, TrainingLevel trainingLevel)
    {
        lesson.SetTrainingLevel(trainingLevel);
    }

    public void SetLessonType(ILesson lesson, LessonType lessonType)
    {
        lesson.SetLessonType(lessonType);
    }

    public void SetMaxStudents(ILesson lesson, int maxStudents)
    {
        lesson.SetMaxStudents(maxStudents);
    }

    public string GetName(ILesson lesson) => lesson.GetName();
    public string GetDescription(ILesson lesson) => lesson.GetDescription();
    public TrainingLevel GetTrainingLevel(ILesson lesson) => lesson.GetTrainingLevel();

    public LessonType GetLessonType(ILesson lesson) => lesson.GetLessonType();

    public int GetMaxStudents(ILesson lesson) => lesson.GetMaxStudents();
    
    public void RemoveTrainer(ILesson? lesson)
    {
        if (lesson == null)
            throw new InvalidOperationException("Cannot assign the trainer. Lesson is defined.");

        lesson.RemoveTrainer();
    }
    public void Reschedule(ILesson? lesson, DateTime dateFrom, int duration)
    {
        if (lesson == null)
            throw new InvalidOperationException("Cannot assign the trainer. Lesson is defined.");
        lesson.Reschedule(dateFrom, duration);
    }


}