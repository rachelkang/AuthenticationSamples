using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Google.Apis.Util.Store;
using Microsoft.Maui.Controls;

using MIAUI.Model;
using MIAUI.Services;
//using static Android.Content.ClipData;
using Google.Apis;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using MIAUI.Views;
using Task = System.Threading.Tasks.Task;

namespace MIAUI.ViewModels
{
    public partial class TasksViewModel : BaseViewModel
    {
        public TasksViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        bool isBusy = false;

        [ObservableProperty]
        string taskName; //Task's title

        [ICommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(TaskName))
                return;
            //add TaskName
            Items.Add(TaskName);
            TaskName = string.Empty;
        }

        [ICommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }

        [ICommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?Text{s}");
        }
    }
}
