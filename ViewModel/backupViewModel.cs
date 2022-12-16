using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using V_3._0.Model;
using System.Linq;
using System.Threading.Tasks;
using V_3._0.Commands;
using System.Collections.ObjectModel;
using System.IO;

namespace V_3._0.ViewModel
{
    public class backupViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));


        }
        #endregion


        BackupService ObjbackupService;
        public backupViewModel()
        {
            ObjbackupService = new BackupService();
            LoadData();
            CurrentBackup = new Backup();
            saveCommand = new RelayCommand(Save);
            
        }

        #region DisplayOperation
        private ObservableCollection<Backup> backupList;

        public ObservableCollection<Backup> BackupList
        {
            get { return backupList; }
            set { backupList = value; OnPropertyChanged("backupList"); }
        }
        private void LoadData()
        {
            BackupList = new ObservableCollection<Backup> (ObjbackupService.GetAll());
        }
        #endregion
        private string message;

        public string Message
        {

            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private Backup currentBackup;
        public Backup CurrentBackup
        {

            get { return currentBackup; }
            set { currentBackup = value; OnPropertyChanged("CurrentBackup"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            
        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjbackupService.Add(CurrentBackup);
                LoadData();
                
                if (!Directory.Exists(CurrentBackup.Destination_Path))
                {
                    Directory.CreateDirectory(CurrentBackup.Destination_Path);
                }
                foreach (var srcPath in Directory.GetFiles(CurrentBackup.Source_Path))
                {
                    //Copy the file from sourcepath and place into mentioned target path, 
                    //Overwrite the file if same file is exist in target path
                    File.Copy(srcPath, srcPath.Replace(CurrentBackup.Source_Path, CurrentBackup.Destination_Path), true);
                }
                if (IsSaved)
                    Message = "The Backup is running, don't close the window until the process is finished";
                else
                    Message = "Backup operation failed";
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }


    }

}
