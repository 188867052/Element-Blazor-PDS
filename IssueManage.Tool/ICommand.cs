namespace IssueManage.Tool
{
    public interface ICommand<T>
    {
        void OnExecuting(T parameter) { }
        void Execute(T parameter);
        void OnExecuted(T parameter) { }
    }
}
