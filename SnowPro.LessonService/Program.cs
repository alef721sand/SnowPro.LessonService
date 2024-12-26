using System.Globalization;
using SnowPro.LessonService.Commands;
using SnowPro.LessonService.Commands.Admin;
using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Commands.Trainer;
using SnowPro.LessonService.Core.Base;

var students = new Dictionary<Guid, string>
{
    { Guid.NewGuid(), "Алексей Соколов" },
    { Guid.NewGuid(), "Мария Лебедева" },
    { Guid.NewGuid(), "Сергей Морозов" },
    { Guid.NewGuid(), "Елена Новикова" },
    { Guid.NewGuid(), "Михаил Петров" },
    { Guid.NewGuid(), "Наталья Федорова" },
    { Guid.NewGuid(), "Андрей Васильев" },
    { Guid.NewGuid(), "Екатерина Михайлова" },
    { Guid.NewGuid(), "Владимир Павлов" },
    { Guid.NewGuid(), "Юлия Семенова" },
    { Guid.NewGuid(), "Артем Киселев" }
};
var trainers = new Dictionary<Guid, string>
{
    { Guid.NewGuid(), "Иван Иванов" },
    { Guid.NewGuid(), "Анна Смирнова" },
    { Guid.NewGuid(), "Дмитрий Кузнецов" },
    { Guid.NewGuid(), "Ольга Попова" }
};

var admin = new Admin(Guid.NewGuid());

var trainer = new Trainer(Guid.NewGuid());
var student = new Student(Guid.NewGuid());
var lesson = new Lesson(
    Guid.NewGuid(), 
    "Math", 
    "Basic Math Lesson", 
    DateTime.Today, 
    60, 
    TrainingLevel.Beginner,
    LessonType.None,
    10);


var enrollStudentCommand = new AdminEnrollCommand(admin, lesson, student);
var completeLessonCommand = new TrainerCompleteLessonCommand(trainer, lesson);
var adminUnEnrollCommand = new AdminUnEnrollCommand(admin, lesson, student);


var invoker = new CommandInvoker();


invoker.AddCommand(enrollStudentCommand);
invoker.AddCommand(completeLessonCommand);
invoker.AddCommand(adminUnEnrollCommand);


invoker.ExecuteCommands();
