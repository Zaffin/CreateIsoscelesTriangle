using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CreateIsoscelesTriangle.Views;
using CreateIsoscelesTriangle.Services;
using CreateIsoscelesTriangle.ViewModels;

using Mastercam.App;
using Mastercam.App.Types;


namespace CreateIsoscelesTriangle
{
    public class Main : NetHook3App
    {

        public override MCamReturn Run(int param)
        {
            var mainView = new MainView()
            {
                DataContext = new MainViewViewModel(new TriangleService())
            };

            var ownerWindowHandle = Mastercam.Support.UI.MastercamWindow.GetHandle().Handle;

            _ = new System.Windows.Interop.WindowInteropHelper(mainView) { Owner = ownerWindowHandle };

            mainView.Show();

            return MCamReturn.NoErrors;
        }

    }
}
