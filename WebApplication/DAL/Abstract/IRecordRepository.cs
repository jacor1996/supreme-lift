using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRecordRepository
    {
        IEnumerable<Record> GetRecords();

        IEnumerable<Record> GetRecords(User user);

        Record FindRecord(int id);

        void AddRecord(Record record);

        void DeleteRecord(Record record);

        User FindUser(string userName);

        Exercise FindExercise(int id);

        IEnumerable<Exercise> GetExercises();
    }
}
