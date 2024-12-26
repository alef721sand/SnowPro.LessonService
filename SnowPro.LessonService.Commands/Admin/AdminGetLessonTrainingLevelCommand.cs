using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin;

public class AdminGetLessonTrainingLevelCommand(IAdmin admin, ILesson lesson) : ICommand<TrainingLevel>
{
    private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
    private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));
    public TrainingLevel Execute()
    {
        return  _admin.GetTrainingLevel(_lesson);
    }

}