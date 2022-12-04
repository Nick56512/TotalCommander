using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL.DTO;
using BLL.Services;
using TotalCommander.Infrastructure;
using TotalCommander.Views;

namespace TotalCommander.ViewModels
{
    class ListFilesAndDirectoriesViewModel:BaseNotifyPropertyChanged
    {
       
        public UserControl Panel2 { get; set; }

        ObservableCollection<IDto> filesAndFolders;
        public ObservableCollection<IDto> FilesAndFolders 
        { 
            get=>filesAndFolders;
            set
            {
                filesAndFolders = value;
                NotifyOfPopertyChanged();
            }
        }
        public ObservableCollection<string> Drives { get; set; }

        string currentDrive;
        public string CurrentDrive
        {
            get => currentDrive;
            set
            {
                currentDrive = value;
                NotifyOfPopertyChanged();
                GoInDrive();
            }
        }
        string path;
        public string CurrentPath 
        {
            get=>path;
            set
            {
                path = value;
                NotifyOfPopertyChanged();
            }
        }

        FileService fileService;
        FolderService folderService;

        public IDto CurrentObj { get; set; }

        private void UploadDrives()
        {
            Drives = new ObservableCollection<string>();
            foreach (var item in DriveInfo.GetDrives())
            {
                Drives.Add(item.Name);
            }
        }
        private Task UploadFilesAndFoldersOfPath()
        {
            return Task.Run(() =>
            {
                List<IDto> dtos = new List<IDto>();
               
                dtos.AddRange(folderService.GetAll(CurrentPath));
                dtos.AddRange(fileService.GetAll(CurrentPath));

                FilesAndFolders = new ObservableCollection<IDto>(dtos);
              
            }); 
        }
        public ListFilesAndDirectoriesViewModel(FileService fileService,FolderService folderService)
        {
            UploadDrives();
           
            this.fileService = fileService;
            this.folderService = folderService;

            CurrentPath = Drives[0];   
            CurrentDrive = Drives[0];

            UploadFilesAndFoldersOfPath();

            CreateCommands();
        }
        private void CreateCommands()
        {
            GoInFolderCommand = new RelayCommand(GoInFolder);
            GoBackCommand = new RelayCommand(GoBack);
            CopyCommand = new RelayCommand(Copy);
            MoveCommand=new RelayCommand(Move);
      
        }
        private async void Move(object param)
        {
            if(CurrentObj is FileDTO)
            {
                ListFilesAndDirectoriesViewModel viewModel = (Panel2.DataContext as ListFilesAndDirectoriesViewModel);
                try
                {
                    await fileService.Move(CurrentObj.Path,
                          viewModel.CurrentPath + @"\" + CurrentObj.Name);

                    viewModel.FilesAndFolders.Add(CurrentObj);
                    FilesAndFolders.Remove(CurrentObj);
                }
                catch (Exception e) 
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        private async void Copy(object param)
        {
            if (CurrentObj is FileDTO)
            {
                
                ListFilesAndDirectoriesViewModel viewModel = (Panel2.DataContext as ListFilesAndDirectoriesViewModel);
                if (viewModel.CurrentPath != CurrentPath)
                {
                    ProgressWindow window = new ProgressWindow();
                    window.Show();
                    ProgressViewModel progress = (window.DataContext as ProgressViewModel);
                    try
                    {
                            progress.Maximum = fileService.GetSizeFileInBytes(CurrentObj.Path);
                            await fileService.Copy(

                                CurrentObj.Path,
                                viewModel.CurrentPath + @"\" + CurrentObj.Name, progress.CalculatePercents

                                );
                            viewModel.FilesAndFolders.Add(CurrentObj);
                      
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                     window.Close();
                }
            }
        }
        private async void GoInFolder(object obj)
        {
            if(CurrentObj is FolderDTO)
            {
                CurrentPath = CurrentObj.Path;
                await UploadFilesAndFoldersOfPath();
            }
        }
        private async void GoBack(object obj)
        {
            if(CurrentPath!=CurrentDrive)
            {
                int lastSleshIndex = CurrentPath.LastIndexOf(@"\");
                if(CurrentPath[lastSleshIndex-1]==':')
                {
                    GoInDrive();
                }
                else
                {
                    CurrentPath = CurrentPath.Substring(0,lastSleshIndex);
                    await UploadFilesAndFoldersOfPath();
                }
            }
        }

        public async void GoInDrive()
        {
            CurrentPath = CurrentDrive;
            await UploadFilesAndFoldersOfPath(); 
        }

        public ICommand GoInFolderCommand { get; private set; }
        public ICommand GoBackCommand { get; private set; }
        public ICommand CopyCommand { get; private set; }
        public ICommand MoveCommand { get; private set; }  
    }
}
