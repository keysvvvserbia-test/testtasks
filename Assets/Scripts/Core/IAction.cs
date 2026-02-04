namespace Core
{
    public interface IAction
    {
        bool CanExecute();
        void Execute();
    }
}

