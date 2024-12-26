using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin;

public class AdminGetLessonTypeCommand(IAdmin admin, ILesson lesson) : ICommand<LessonType>
{
    private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
    private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));

    public LessonType Execute()
    {
        return _admin.GetLessonType(_lesson);
    }
}