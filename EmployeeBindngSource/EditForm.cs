using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeBindngSource.Model;

namespace EmployeeBindngSource
{
    public partial class EditForm : Form
    {
        Employee emp = new Employee();
        EmployeeTaskEntities db = new EmployeeTaskEntities();


        public EditForm(Employee employee , EmployeeTaskEntities db)
        {
            InitializeComponent();
            this.emp = employee;
            this.db = db;

        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = emp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            emp = employeeBindingSource.DataSource as Employee;
            var emp2 = db.Employees.Where(x => x.EmpId == emp.EmpId).First();
            db.Entry(emp).State = EntityState.Modified;


            db.SaveChanges();
            MessageBox.Show("Recored Edit");

        }

        

        private void employeeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
