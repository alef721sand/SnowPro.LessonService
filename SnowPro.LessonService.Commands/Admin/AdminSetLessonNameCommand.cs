using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin
{
    public class AdminSetLessonNameCommand(IAdmin admin, ILesson lesson, string value) : ICommand
    {
        private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
        private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));
        private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));
        public void Execute()
        {
            _admin.SetName(_lesson, _value);
        }
    }
}
