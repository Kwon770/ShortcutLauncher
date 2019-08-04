﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace ShortcutLauncher
{
    /// <summary>
    /// EditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditWindow : Window
    {
        private bool isFile = false;
        private int index;

        public EditWindow(int _index)
        {
            InitializeComponent();

            index = _index;
        }

        private void ApplyButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(iconPathBlock.Text) || (string.IsNullOrWhiteSpace(filePathBlock.Text) && string.IsNullOrWhiteSpace(linkBox.Text)) )
            {
                MessageBox.Show("아이콘 정보를 모두 입력하세요", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (isFile)
                {
                    MainWindow.Add_NewIcon(index, isFile, nameBox.Text, iconPathBlock.Text, filePathBlock.Text);
                }
                else
                {
                    MainWindow.Add_NewIcon(index, isFile, nameBox.Text, iconPathBlock.Text, linkBox.Text);
                }
            }
        }

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IconPathLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        public void Click_PathCheckbox()
        {
            isFile = true;

            filePathBlock.Visibility = Visibility.Visible;

            linkCheckBox.IsChecked = false;
            linkBox.Visibility = Visibility.Hidden;
        }

        public void Click_LinkCheckbox()
        {
            isFile = false;

            linkBox.Visibility = Visibility.Visible;

            pathCheckBox.IsChecked = false;
            filePathBlock.Visibility = Visibility.Hidden;
        }

        private void FilePathLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GetName_FileExplorer();
        }

        private string GetName_FileExplorer()
        {
            OpenFileDialog dig = new OpenFileDialog();

            bool? result = dig.ShowDialog();

            if (result == true) return dig.FileName;
            else return string.Empty;
        }

    }
}