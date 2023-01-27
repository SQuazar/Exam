namespace Exam.ViewModels.Factories
{
    internal class ViewModelFactory
    {
        private readonly ViewModelBase.CreateViewModel<NotFoundViewModel> _createNotFoundViewModel;
        private readonly ViewModelBase.CreateViewModel<FirstViewModel> _createFirstViewModel;

        public ViewModelFactory(ViewModelBase.CreateViewModel<NotFoundViewModel> createNotFoundViewModel,
            ViewModelBase.CreateViewModel<FirstViewModel> createFirstViewModel)
        {
            _createNotFoundViewModel = createNotFoundViewModel;
            _createFirstViewModel = createFirstViewModel;
        }

        public ViewModelBase? Create(ViewType type)
        {
            return type switch
            {
                ViewType.Home => _createFirstViewModel(),
                _ => _createNotFoundViewModel(),
            };
        }
    }

    internal enum ViewType
    {
        NotFound,
        Home
    }
}
