using EmployeeBindngSource.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeBindngSource
{
    public partial class Form1 : Form
    {
        EmployeeTaskEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new EmployeeTaskEntities();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Row = employeeBindingSource.Current as Employee;

            if (e.ColumnIndex == 6)
            {
                db.Employees.Remove(Row);
                db.SaveChanges();
                MessageBox.Show("Record has been Removed");

            }

            if (e.ColumnIndex == 7)
            {
                EditForm frm = new EditForm(Row,db);
                frm.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = db.Employees.ToList();

            List<Department> depts= db.Departments.ToList();
            departmentBindingSource.DataSource = depts;

            employeeBindingSource.AddNew();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            List<Employee> employees = employeeBindingSource.DataSource as List<Employee>;
            var emps = employees.Where(x => x.EmpId == 0).ToList();
            foreach(var emp in emps)
            {
                db.Employees.Add(emp);
            }
            db.SaveChanges();
        }

      
    }
}
