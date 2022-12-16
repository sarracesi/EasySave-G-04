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
                new Backup()
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
