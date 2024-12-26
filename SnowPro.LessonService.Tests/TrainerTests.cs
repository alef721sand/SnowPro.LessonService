using Moq;
using SnowPro.LessonService.Commands;
using SnowPro.LessonService.Commands.Trainer;
using SnowPro.LessonService.Core.Interfaces;
using Xunit;

namespace SnowPro.LessonService.Tests;
public class TrainerTests
{
    [Fact]
    public void Trainer_ShouldStartLesson()
    {
        var lessonMock = new Mock<ILesson>();
        var trainerMock = new Mock<ITrainer>();

        trainerMock.Setup(a => a.StartLesson(lessonMock.Object));

        var command = new TrainerStartLessonCommand(trainerMock.Object, lessonMock.Object);
        command.Execute();

        trainerMock.Verify(a => a.StartLesson(lessonMock.Object), Times.Once);
    }
    [Fact]
    public void Trainer_ShouldCompleteLesson()
    {
        var lessonMock = new Mock<ILesson>();
        var trainerMock = new Mock<ITrainer>();

        trainerMock.Setup(a => a.CompleteLesson(lessonMock.Object));

        var command = new TrainerCompleteLessonCommand(trainerMock.Object, lessonMock.Object);
        command.Execute();

        trainerMock.Verify(a => a.CompleteLesson(lessonMock.Object), Times.Once);
    }
    [Fact]
    public void Trainer_ShouldCancelLesson()
    {
        var lessonMock = new Mock<ILesson>();
        var trainerMock = new Mock<ITrainer>();

        trainerMock.Setup(a => a.CancelLesson(lessonMock.Object));

        var command = new TrainerCancelLessonCommand(trainerMock.Object, lessonMock.Object);
        command.Execute();

        trainerMock.Verify(a => a.CancelLesson(lessonMock.Object), Times.Once);
    }

}
