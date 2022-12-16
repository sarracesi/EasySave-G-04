using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace V_3._0.Model
{
    class BackupService
    {
        private static List<Backup> ObjBackupsList;

        public BackupService()
        {
            ObjBackupsList = new List<Backup>()
            {
                new Backup{ID=1, Backup_Name= "save1",Folder_Name="Folder1", Source_Path= "C:\\Users\\26\\Desktop\\Demo", Destination_Path= "C:\\Users\\26\\Desktop\\Demo\\Folder2"}
            };
        }

        public List<Backup> GetAll()
        {
            return ObjBackupsList;
        }

        public bool Add(Backup ObjNewBackup)
        {
            ObjBackupsList.Add(ObjNewBackup);
            return true;
        }
    }
}
