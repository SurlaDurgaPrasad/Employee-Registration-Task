using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
namespace Employee_Registration_Task.Model
{
    public class Employee
    {
    
        [Required(ErrorMessage ="Id is required Field")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required Field")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minumum char is 5 and maximum char is 50")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "job is required Field")]

        public string? Job {  get; set; }
        [Required(ErrorMessage = "salary is required Field")]

        public int  salary { get; set; }

        SqlConnection Con = new SqlConnection("Data source=.;DataBase=Celibari;TrustServerCertificate=True;integrated security=yes");
        public List<Employee> GetEmployeesData()
        {
            Con.Open();
            SqlCommand Cmd =  new SqlCommand("select * From Emp1",Con);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);   
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> LiEmp = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                LiEmp.Add(
                    new Employee
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Job = Convert.ToString(dr["Job"]),
                        salary = Convert.ToInt32(dr["salary"])

                    });
                    
            }
            return LiEmp;


        }
        public void Adddetails(Employee obj)
        {
            Con.Open();
            SqlCommand cmd =new  SqlCommand("insert into Emp1 Values('"+obj.Id+"','"+obj.Name+"','"+obj.Job+ "','"+obj.salary+"')", Con);
            cmd.ExecuteNonQuery();
            Con.Close();

        }
    }
}
