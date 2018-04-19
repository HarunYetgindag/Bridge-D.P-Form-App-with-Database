
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_DP_Odev
{

    interface IDataObject<T>
    {

        Student NextRecord();
        Student PriorRecord();
        void AddRecord(T t);
        void DeleteRecord(int t);
        T GetCurrentRecord();
        Student ShowRecord();
        List<Student> ShowAllRecord();
    }

    /* ---------------------------------- */

    abstract class StudentBusinessBase  /*  */
    {
        public IDataObject<Student> DataObject { get; set; }

        public virtual Student Next()
        {
            return DataObject.NextRecord();
        }

        public virtual Student Prior()
        {
            return DataObject.PriorRecord();
        }

        public virtual void Add(Student t)
        {
            DataObject.AddRecord(t);
        }

        public virtual void Delete(int t)
        {
            DataObject.DeleteRecord(t);
        }

        public virtual void Show()
        {
            DataObject.ShowRecord();
        }

        public virtual List<Student> ShowAll()
        {
            return DataObject.ShowAllRecord();
        }
    }

    /* *********************************** */


    class StudentsBusiness : StudentBusinessBase  // ****
    {
        public override List<Student> ShowAll()
        {
            return base.ShowAll();
        }
        public override void Add(Student t)
        {
            base.Add(t);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }

        public override Student Next()
        {
            return base.Next();
        }

        public override Student Prior()
        {
            return base.Prior();
        }

        public override void Show()
        {
            base.Show();
        }


    }

    /* ---------------------------------- */

    class StudentDataManagement : IDataObject<Student>
    {


        private List<Student> _students;

        private int _curent = 0;

        public StudentDataManagement()
        {
            using (SchoolDbEntities db = new SchoolDbEntities())
            {
                _students = db.Students.ToList();
            }
            
        }
        public void AddRecord(Student t)
        {
            using (SchoolDbEntities db = new SchoolDbEntities())
            {
                db.Students.Add(t);
                db.SaveChanges();
            }
            
        }

        public void DeleteRecord(int id)
        {
            using (SchoolDbEntities db = new SchoolDbEntities())
            {
                var d = db.Students.Where(s => s.Id == id).FirstOrDefault();

                db.Students.Remove(d);
                db.SaveChanges();
            }
            
        }

        public Student GetCurrentRecord()
        {
            return _students[_curent];
        }

        public Student NextRecord()
        {
            if (_curent < _students.Count) 
            {
                _curent++;

            }
            return _students[_curent];
        }

        public Student PriorRecord()
        {
            if (_curent > 0)
            {
                _curent--;

            }
            return _students[_curent];
        }

        public List<Student> ShowAllRecord()
        {

            return _students;
        }

        public Student ShowRecord()
        {
            return _students[_curent];
        }


    }

}
