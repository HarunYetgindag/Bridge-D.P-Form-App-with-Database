using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bridge_DP_Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var students = new StudentsBusiness();

            students.DataObject = new StudentDataManagement();

            dataGridView1.DataSource = students.ShowAll();
            previous();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var students = new StudentsBusiness();

            students.DataObject = new StudentDataManagement();

            Student s = new Student
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Department = txtDepartment.Text
            };

            students.Add(s);


           
            SchoolDbEntities db = new SchoolDbEntities();

            dataGridView1.DataSource = db.Students.ToList();
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            previous();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var students = new StudentsBusiness();
            students.DataObject = new StudentDataManagement();

            int id = Convert.ToInt32(txtId.Text);

            students.Delete(id);

            

            SchoolDbEntities db = new SchoolDbEntities();

            dataGridView1.DataSource = db.Students.ToList();
            
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            next();
            
        }

        private void next()
        {
            var students = new StudentsBusiness();
            students.DataObject = new StudentDataManagement();

            Student s = students.Next();
            txtFirstName.Text = s.FirstName;
            txtLastName.Text = s.LastName;
            txtDepartment.Text = s.Department;
            txtId.Text = s.Id.ToString();
        }

        private void previous()
        {
            var students = new StudentsBusiness();
            students.DataObject = new StudentDataManagement();

            Student s = students.Prior();
            txtFirstName.Text = s.FirstName;
            txtLastName.Text = s.LastName;
            txtDepartment.Text = s.Department;
            txtId.Text = s.Id.ToString();
        }
    }
}
