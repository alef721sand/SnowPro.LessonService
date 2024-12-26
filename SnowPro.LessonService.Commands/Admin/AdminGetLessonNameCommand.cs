﻿using SnowPro.LessonService.Commands.Base;
using SnowPro.LessonService.Core.Interfaces;

namespace SnowPro.LessonService.Commands.Admin;

public class AdminGetLessonNameCommand(IAdmin admin, ILesson lesson) : ICommand<string>
{
    private readonly IAdmin _admin = admin ?? throw new ArgumentNullException(nameof(admin));
    private readonly ILesson _lesson = lesson ?? throw new ArgumentNullException(nameof(lesson));
    public string Execute()
    {
        return _admin.GetName(_lesson);
    }
}