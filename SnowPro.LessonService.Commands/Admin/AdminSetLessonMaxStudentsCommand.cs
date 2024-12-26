using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin;

public class AdminSetLessonMaxStudentsCommand(IAdmin admin, ILesson lesson, int maxStudents): ICommand
{
    private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
    private readonly int _maxStudents = maxStudents < 1 ? throw new ArgumentNullException(nameof(maxStudents)) : maxStudents;
    private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));
    public void Execute()
    {
        _admin.SetMaxStudents(_lesson, _maxStudents);
    }
}