using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class RecordRepository : IRecordRepository
    {
        private SupremeLiftDbEntities _repository;

        public RecordRepository()
        {
            _repository = new SupremeLiftDbEntities();
        }

        public IEnumerable<Record> GetRecords()
        {
            return _repository.Records
                .Include(e => e.Exercise)
                .Include(u => u.User);
        }

        public IEnumerable<Record> GetRecords(User user)
        {
            return GetRecords().Where(u => u.User.Name == user.Name);
        }

        public Record FindRecord(int id)
        {
            return GetRecords().FirstOrDefault(r => r.RecordId == id);
        }

        public void AddRecord(Record record)
        {
            Record recordEntity = FindRecord(record.RecordId);

            if (recordEntity == null)
            {
                _repository.Records.Add(record);
            }

            else
            {
                recordEntity.User = record.User;
                recordEntity.Date = record.Date;
                recordEntity.Exercise = record.Exercise;
                recordEntity.Fk_ExerciseId = record.Fk_ExerciseId;
                recordEntity.Fk_UserId = record.Fk_UserId;
                recordEntity.RecordId = record.RecordId;
                recordEntity.WeightLifted = record.WeightLifted;
            }

            _repository.SaveChanges();
        }

        public void DeleteRecord(Record record)
        {
            throw new NotImplementedException();
        }
    }
}
