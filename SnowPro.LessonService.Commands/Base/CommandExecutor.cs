namespace SnowPro.LessonService.Commands.Base;

public class CommandExecutor
{
    public void Execute(ICommand command)
    {
        command.Execute();
    }

    public TResult Execute<TResult>(ICommand<TResult> command)
    {
        return command.Execute();
    }
}
