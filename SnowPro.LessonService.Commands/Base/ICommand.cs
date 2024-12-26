namespace SnowPro.LessonService.Commands.Base
{
    public interface ICommand<out TResult>
    {
        TResult Execute();
    }
    public interface ICommand
    {
        void Execute();
    }
}
