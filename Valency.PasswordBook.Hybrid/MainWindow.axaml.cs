using System;
using Avalonia.Controls;

namespace Valency.PasswordBook.Hybrid;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void MainListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
	{
		// 找到被双击的视觉元素
		var listBox = sender as ListBox;

		// 关键点：SelectedItem 此时已经是你双击的那一项了
		if (listBox?.SelectedItem is string selectedItem)
		{
			var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
			clipboard?.SetTextAsync(selectedItem);
		}
	}

	private void MainListBox_DoubleTapped_1(object? sender, Avalonia.Input.TappedEventArgs e)
	{
	}
}