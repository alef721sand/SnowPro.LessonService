using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin;

public class AdminSetLessonTrainingLevelCommand(IAdmin admin, ILesson lesson, TrainingLevel value) : ICommand
{
    private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
    private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));
    public void Execute()
    {
        _admin.SetTrainingLevel(_lesson, value);
    }
}