﻿using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERAL_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthenticationController _authenticationController = new();
        public MainWindow()
        {
            DataContext = _authenticationController;
            OnNextPage += Next;
            InitializeComponent();
        }

        #region Event
        public delegate void NextPage();
        public event NextPage OnNextPage;
        private void Next()
        {
            if (_authenticationController.Response is "ok")
            {
                WorkWindow workWindow = new();
                workWindow.Show();
                Close();
            }
        }
        #endregion

        // TODO: поправить событие срабатывания
        private void Page_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            OnNextPage();
        }
    }
}
