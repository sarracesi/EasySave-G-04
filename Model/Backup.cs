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

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
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


        private string source_Path;

        public string Source_Path
        {
            get { return source_Path; }
            set { source_Path = value; OnPropertyChanged("Source_Path"); }
        }

        private string destination_Path;

        public string Destination_Path
        {
            get { return destination_Path; }
            set { destination_Path = value; OnPropertyChanged("Destination_Path"); }
        }





    }
}
