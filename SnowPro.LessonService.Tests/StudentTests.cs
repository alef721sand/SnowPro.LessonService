using Moq;
using SnowPro.LessonService.Commands;
using SnowPro.LessonService.Commands.Student;
using SnowPro.LessonService.Core.Interfaces;
using Xunit;

namespace SnowPro.LessonService.Tests;
public class StudentTests
{
    [Fact]
    public void Student_ShouldEnrollToLesson()
    {
        var lessonMock = new Mock<ILesson>();
        var studentMock = new Mock<IStudent>();

        studentMock.Setup(a => a.Enroll(lessonMock.Object));

        var command = new StudentEnrollCommand(lessonMock.Object, studentMock.Object);
        command.Execute();

        studentMock.Verify(a => a.Enroll(lessonMock.Object), Times.Once);
    }
    [Fact]
    public void Student_ShouldUnEnrollToLesson()
    {
        var lessonMock = new Mock<ILesson>();
        var studentMock = new Mock<IStudent>();

        studentMock.Setup(a => a.UnEnroll(lessonMock.Object));

        var command = new StudentUnEnrollCommand(lessonMock.Object, studentMock.Object);
        command.Execute();

        studentMock.Verify(a => a.UnEnroll(lessonMock.Object), Times.Once);
    }
}
