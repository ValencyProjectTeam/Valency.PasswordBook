using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Valency.PasswordBook.Hybrid.ViewModels
{
	internal partial class MainWindowViewModel:ObservableObject
	{
		[RelayCommand]
		public void CreateNew()
		{
			Passwords.Add(Guid.NewGuid().ToString());
		}

		[RelayCommand]
		public void RemoveAll()
		{
			Passwords.Clear();
		}

		public ObservableCollection<string> Passwords { get; }=new();

		// --- 删除命令 ---
		[RelayCommand]
		private void Delete(string item)
		{
			if (item != null)
			{
				Passwords.Remove(item);
			}
		}

		// --- 复制命令 ---
		[RelayCommand]
		private async Task Copy(String item)
		{
			if (item == null) return;

			// 获取剪切板（使用前面提到的跨平台方式）
			if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				var clipboard = desktop.MainWindow?.Clipboard;
				if (clipboard != null)
				{
					await clipboard.SetTextAsync(item); // 假设 MyItem 有 Content 属性
				}
			}
		}

		// --- 编辑命令 ---
		[RelayCommand]
		private void Edit(string item)
		{
			if (item == null) return;

			// 示例：简单修改内容
			//item = "编辑后的内容";
			// 注意：如果 MyItem 也要通知 UI 更新，它也需要继承 ObservableObject 并对属性加 [ObservableProperty]
		}
	}
}
