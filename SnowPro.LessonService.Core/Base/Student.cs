using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Core.Base
{
    public class Student(Guid id) : Person(id), IStudent
    {
        public void Enroll(ILesson? lesson)
        {
            if (lesson == null)
                throw new InvalidOperationException("Cannot enroll the student. Lesson is defined.");
            lesson.EnrollStudent(this);
        }

        public void UnEnroll(ILesson? lesson)
        {
            if (lesson == null)
                throw new InvalidOperationException("Cannot UnEnroll the student. Lesson is defined.");
            lesson.UnEnrollStudent(this);
        }
    }
}
