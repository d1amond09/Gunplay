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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gunplay.View
{
	public partial class SettingsPage : Page
	{
		public SettingsPage()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Content = null;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
