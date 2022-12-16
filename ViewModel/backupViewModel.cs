using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using V_3._0.Model;

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
        }

        #region DisplayOperation
        private List<Backup> backupList;

        public List<Backup> BackupList
        {
            get { return backupList; }
            set { backupList = value; OnPropertyChanged("BackupList"); }
        }
        private void LoadData()
        {
            BackupList = ObjbackupService.GetAll();
        }
        #endregion

        private Backup currentBackup;
        public Backup CurrentBackup
        {

            get { return currentBackup; }
            set { currentBackup = value; OnPropertyChanged("CurrentBackup"); }
        }
    }

}
