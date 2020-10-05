using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Mastercam.IO;
using Mastercam.Math;

using CreateIsoscelesTriangle.Commands;
using CreateIsoscelesTriangle.Services;
using CreateIsoscelesTriangle.DataTypes;
using CreateIsoscelesTriangle.Resources;

namespace CreateIsoscelesTriangle.ViewModels
{
    public class MainViewViewModel : ViewModelBase
    {
        private readonly ITriangleService triangleService;

        private TriangleBasePosition basePosition;

        private double width;

        private double height;

        public IsoscelesTriangleDetails triangleDetails;

        public Point3D SelectedPoint { get; set; }

        public TriangleBasePosition BasePosition
        {
            get => this.basePosition;

            set
            {
                this.basePosition = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get => this.width;

            set
            {
                this.width = value;
                TriangleDetails = triangleService.GetTriangleDetails(Width, Height);
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get => this.height;

            set
            {
                this.height = value;
                TriangleDetails = triangleService.GetTriangleDetails(Width, Height);
                OnPropertyChanged();
            }
        }

        public IsoscelesTriangleDetails TriangleDetails
        {
            get => this.triangleDetails;

            set
            {
                this.triangleDetails = value;
                OnPropertyChanged();
            }
        }

        public MainViewViewModel(ITriangleService triangleService)
        {
            this.triangleService = triangleService;

            OkNewCommand = new DelegateCommand(OnOkNewCommand);
            OkCommand = new DelegateCommand(OnOkCommand);
            CloseCommand = new DelegateCommand(OnCloseCommand);

            SelectOriginCommand = new DelegateCommand(OnSelectOriginCommand);

            BasePosition = TriangleBasePosition.Top;

            Width = 1;
            Height = 3;

            TriangleDetails = triangleService.GetTriangleDetails(Width, Height);
        }

        public DelegateCommand OkNewCommand { get; }

        public DelegateCommand OkCommand { get; }

        public DelegateCommand CloseCommand { get; }

        public DelegateCommand SelectOriginCommand { get; }

        private void OnOkNewCommand(object parameter)
        {
            triangleService.CreateTriangle(SelectedPoint, BasePosition, Width, Height);
        }

        private void OnOkCommand(object parameter)
        {
            var view = (Window)parameter;

            triangleService.CreateTriangle(SelectedPoint, BasePosition, Width, Height);

            view?.Close();

        }

        private void OnCloseCommand(object parameter)
        {
            var view = (Window)parameter;

            view?.Close();

        }

        private void OnSelectOriginCommand(object parameter)
        {
            var view = (Window)parameter;

            view?.Hide();

            SelectedPoint = triangleService.SelectPoint(UIStrings.SelectOriginPrompt);

            view?.Show();

        }

    }
}
