using LaererVikaren.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaererVikaren.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegCaliperPage.xaml
    /// </summary>
    public partial class FindMatchingSubstitutePage : Page
    {
        CreateLessonViewModel clvm = new();
        public FindMatchingSubstitutePage()
        {
            InitializeComponent();
            DataContext = clvm;
        }
    }
}
