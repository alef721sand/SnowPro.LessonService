using System.Threading.Channels;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Core.Base
{
    public enum TrainingLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3,
        Expert = 4,
        Master = 5
    }

    public enum LessonType
    {
        None = 1,
        Freestyle = 2,
        Slalom = 3,
        GiantSlalom = 4,
        Downhill = 5,
        SuperG = 6
    }

    public enum State
    {
        Scheduled = 1,
        InProgress = 2,
        Completed = 3,
        Canceled = 4
    }

    public class Lesson(
        Guid id,
        string name,
        string description,
        DateTime dateFrom,
        int duration,
        TrainingLevel trainingLevel,
        LessonType lessonType,
        int maxStudents) : Entity<Guid>(id), ILesson
    {
        private State _state = State.Scheduled;
        private ITrainer? _trainer;
        private readonly List<IStudent?> _students = [];

        public Guid Id { get; } = id;
        public string GetName() => name;
        public string GetDescription() => description;
        public DateTime GetDateFrom() => dateFrom;
        public int GetDuration() => duration;
        public TrainingLevel GetTrainingLevel() => trainingLevel;
        public LessonType GetLessonType() => lessonType;
        public int GetMaxStudents() => maxStudents;

        public State GetState() => _state;
        public ITrainer? GetTrainer() => _trainer;
        public List<IStudent?> GetStudents() => _students;

        public void SetName(string value) => name = value;
        public void SetDescription(string value) => description = value;
        public void SetTrainingLevel(TrainingLevel value) => trainingLevel = value;
        public void SetLessonType(LessonType value) => lessonType = value;

        public void SetMaxStudents(int value) => maxStudents = value;

       public void EnrollStudent(IStudent? student)
        {
            if (_students.Count >= maxStudents)
                throw new InvalidOperationException("Cannot enroll the student. Lesson is full.");

            if (student == null)
                throw new InvalidOperationException("Cannot Add the student. The student is not found.");

            if (_state != State.Scheduled)
            {
                throw _state switch
                {
                    State.Completed => new InvalidOperationException(
                        "Cannot UnEnroll the student. Lesson is completed."),
                    State.InProgress => new InvalidOperationException(
                        "Cannot UnEnroll the student. Lesson is in progress."),
                    _ => new InvalidOperationException("Cannot UnEnroll the student. Lesson is canceled.")
                };
            }

            if (_students.Contains(student))
                throw new InvalidOperationException("Cannot enroll the student. The student is enrolled already.");

            _students.Add(student);
        }

        public void UnEnrollStudent(IStudent? student)
        {
            if (student == null)
                throw new InvalidOperationException("Cannot UnEnroll the student. The student is not found.");

            if (_state != State.Scheduled)
                throw _state switch
                {
                    State.Completed => new InvalidOperationException("Cannot UnEnroll the student. Lesson is completed."),
                    State.InProgress => new InvalidOperationException("Cannot UnEnroll the student. Lesson is in progress."),
                    _ => new InvalidOperationException("Cannot UnEnroll the student. Lesson is canceled.")
                };

            if (!_students.Contains(student))
                throw new InvalidOperationException("Cannot UnEnroll the student. The student is not enrolled.");

            _students.Remove(student);
        }

        public void Reschedule(DateTime dateFromValue, int durationValue)
        {
            if (dateFrom == dateFromValue)
                throw new InvalidOperationException(
                    "Cannot Reschedule Lesson. The current start date/time is equals the new one.");
            if (durationValue <= 1) ;
                throw new InvalidOperationException(
                    "Cannot Reschedule Lesson. The duration value must be grater than 1 min.");
            dateFrom = dateFromValue;
            duration = durationValue;
        }

        public void CancelLesson()
        {
            if (_state != State.Scheduled)
            {
                throw _state switch
                {
                    State.Completed => new InvalidOperationException("Cannot Cancel Lesson. Lesson is completed."),
                    State.InProgress => new InvalidOperationException("Cannot Start Lesson. Lesson is in progress."),
                    _ => new InvalidOperationException("Cannot Cancel Lesson. Lesson is canceled already.")
                };
            }
            _state = State.Canceled;
        }

        public void CompleteLesson()
        {
            if (_state != State.InProgress)
            {
                throw _state switch
                {
                    State.Scheduled => new InvalidOperationException(
                        "Cannot Complete Lesson. Lesson is not started yet."),
                    State.Completed => new InvalidOperationException(
                        "Cannot Complete Lesson. Lesson is completed already."),
                    _ => new InvalidOperationException("Cannot Cancel Lesson. Lesson is canceled."),
                };
            }

            _state = State.Completed;
        }
        public void StartLesson()
        {
            if (_state != State.Scheduled)
            {
                throw _state switch
                {
                    State.Completed => new InvalidOperationException("Cannot Start Lesson. Lesson is completed."),
                    State.InProgress => new InvalidOperationException(
                        "Cannot Start Lesson. Lesson is in progress already."),
                    _ => new InvalidOperationException("Cannot Start Lesson. Lesson is canceled.")
                };
            }            
            _state = State.InProgress;
        }

        public void AssignTrainer(ITrainer? trainer)
        {
            if (trainer == null)
                throw new InvalidOperationException("Cannot Assign the trainer. The trainer is not found.");
            if (_state != State.Scheduled)
            {
                throw _state switch
                {
                    State.Completed => new InvalidOperationException("Cannot Assign the trainer. Lesson is completed."),
                    State.InProgress => new InvalidOperationException(
                        "Cannot Assign the trainer. Lesson is in progress."),
                    _ => new InvalidOperationException("Cannot Assign the trainer. Lesson is canceled.")
                };
            }
            if (_trainer == trainer)
                throw new InvalidOperationException("Cannot Assign the trainer. The same trainer is assigned already.");
            _trainer = trainer;
        }
        public void RemoveTrainer()
        {
            if (_trainer == null)
                throw new InvalidOperationException("Cannot Remove the trainer. The trainer is not assigned.");
            if (_state != State.Scheduled)
            {
                throw _state switch
                {
                    State.Completed => new InvalidOperationException("Cannot Remove the trainer. Lesson is completed."),
                    State.InProgress => new InvalidOperationException(
                        "Cannot Remove the trainer. Lesson is in progress."),
                    _ => new InvalidOperationException("Cannot Remove the trainer. Lesson is canceled.")
                };
            }
            _trainer = null;
        }
    }
}
