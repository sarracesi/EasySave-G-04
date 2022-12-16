using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace V_3._0.Model
{
    public class Backup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        private string backup_Name;

        public string Backup_Name
        {
            get { return backup_Name; }
            set { backup_Name = value;  OnPropertyChanged("Backup_Name"); }
        }


        private string folder_Name;

        public string Folder_Name
        {
            get { return folder_Name; }
            set { folder_Name = value; OnPropertyChanged("Folder_Name"); }
        }


        private string folder_Path;

        public string Folder_Path
        {
            get { return folder_Path; }
            set { folder_Path = value; OnPropertyChanged("Folder_Path"); }
        }

        private string destination_Path;

        public string Destination_Path
        {
            get { return destination_Path; }
            set { destination_Path = value; OnPropertyChanged("Destination_Path"); }
        }





    }
}
