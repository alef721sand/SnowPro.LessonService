using System;
using Moq;
using SnowPro.LessonService.Commands.Admin;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Tests;
public class AdminTests
{
    [Fact]
    public void Admin_ShouldEnrollStudentToLesson()
    {
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        var studentMock = new Mock<IStudent>();

        adminMock.Setup(a => a.Enroll(lessonMock.Object, studentMock.Object));

        var command = new AdminEnrollCommand(adminMock.Object, lessonMock.Object, studentMock.Object);
        command.Execute();

        adminMock.Verify(a => a.Enroll(lessonMock.Object, studentMock.Object), Times.Once);
    }
    [Fact]
    public void Admin_ShouldUnEnrollStudentToLesson()
    {
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        var studentMock = new Mock<IStudent>();

        adminMock.Setup(a => a.UnEnroll(lessonMock.Object, studentMock.Object));

        var command = new AdminUnEnrollCommand(adminMock.Object, lessonMock.Object, studentMock.Object);
        command.Execute();

        adminMock.Verify(a => a.UnEnroll(lessonMock.Object, studentMock.Object), Times.Once);
    }
    [Fact]
    public void Admin_ShouldRemoveTrainerCommand()
    {
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();

        adminMock.Setup(a => a.RemoveTrainer(lessonMock.Object));

        var command = new AdminRemoveTrainerCommand(adminMock.Object, lessonMock.Object);
        command.Execute();

        adminMock.Verify(a => a.RemoveTrainer(lessonMock.Object), Times.Once);
    }
    [Fact]
    public void Admin_ShouldAssignTrainerCommand()
    {
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        var trainerMock = new Mock<ITrainer>();

        adminMock.Setup(a => a.AssignTrainer(lessonMock.Object, trainerMock.Object));

        var command = new AdminAssignTrainerCommand(adminMock.Object, lessonMock.Object, trainerMock.Object);
        command.Execute();

        adminMock.Verify(a => a.AssignTrainer(lessonMock.Object, trainerMock.Object), Times.Once);
    }
    [Fact]
    public void Admin_ShouldRescheduleCommand()
    {
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        var dateFrom = DateTime.Today;
        const int duration = 60;
        adminMock.Setup(a => a.Reschedule(lessonMock.Object, dateFrom, duration));

        var command = new AdminRescheduleCommand(adminMock.Object, lessonMock.Object, dateFrom, duration);
        command.Execute();

        adminMock.Verify(a => a.Reschedule(lessonMock.Object, dateFrom, duration), Times.Once);
    }
    [Fact]
    public void Admin_ShouldReturnLessonName()
    {
        const string name = "John Doe";
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        lessonMock.Setup(t => t.GetName()).Returns(name);
        adminMock.Setup(a => a.GetName(It.IsAny<ILesson>()))
            .Returns((ILesson l) => l.GetName());
        var command = new AdminGetLessonNameCommand(adminMock.Object, lessonMock.Object);

        var result = command.Execute();

        Assert.Equal(name, result);
    }
    [Fact]
    public void Admin_ShouldReturnLessonDescription()
    {
        const string description = "John Doe";
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        lessonMock.Setup(t => t.GetDescription()).Returns(description);
        adminMock.Setup(a => a.GetDescription(It.IsAny<ILesson>()))
            .Returns((ILesson l) => l.GetDescription());
        var command = new AdminGetLessonDescriptionCommand(adminMock.Object, lessonMock.Object);

        var result = command.Execute();

        Assert.Equal(description, result);
    }
    [Fact]
    public void Admin_ShouldReturnLessonMaxStudents()
    {
        const int maxStudents = 60;
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        lessonMock.Setup(t => t.GetMaxStudents()).Returns(maxStudents);
        adminMock.Setup(a => a.GetMaxStudents(It.IsAny<ILesson>()))
            .Returns((ILesson l) => l.GetMaxStudents());
        var command = new AdminGetLessonMaxStudentsCommand(adminMock.Object, lessonMock.Object);

        var result = command.Execute();

        Assert.Equal(maxStudents, result);
    }
    [Fact]
    public void Admin_ShouldReturnLessonTrainingLevel()
    {
        const TrainingLevel trainingLevel = TrainingLevel.Advanced;
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        lessonMock.Setup(t => t.GetTrainingLevel()).Returns(trainingLevel);
        adminMock.Setup(a => a.GetTrainingLevel(It.IsAny<ILesson>()))
            .Returns((ILesson l) => l.GetTrainingLevel());
        var command = new AdminGetLessonTrainingLevelCommand(adminMock.Object, lessonMock.Object);

        var result = command.Execute();

        Assert.Equal(trainingLevel, result);
    }
    [Fact]
    public void Admin_ShouldReturnLessonType()
    {
        const LessonType lessonType = LessonType.Freestyle;
        var adminMock = new Mock<IAdmin>();
        var lessonMock = new Mock<ILesson>();
        lessonMock.Setup(t => t.GetLessonType()).Returns(lessonType);
        adminMock.Setup(a => a.GetLessonType(It.IsAny<ILesson>()))
            .Returns((ILesson l) => l.GetLessonType());
        var command = new AdminGetLessonTypeCommand(adminMock.Object, lessonMock.Object);

        var result = command.Execute();

        Assert.Equal(lessonType, result);
    }

}
