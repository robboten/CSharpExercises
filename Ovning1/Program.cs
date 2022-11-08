//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using Ovning1;
using Ovning1.IO;
using Ovning1.UI;
using System.Windows.Forms;
using static Ovning1.Menu;


internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        ISerialize serializable = new EmployeesSerialize();
        Payroll employees = new(serializable);

        ////postgresql.dosql();
        //   while (true)
        /// {
        //Console.WriteLine($"Enter a command:\n{MenuHelpers.Add} to add new \t{MenuHelpers.List} to list all \t{MenuHelpers.Search} to search for employee \t{MenuHelpers.Quit} to quit");
        //char command = Console.ReadKey().KeyChar;
        //switch (command)
        //{
        //    case MenuHelpers.Quit: Console.WriteLine("\nquitting..."); return;
        //    case MenuHelpers.Add: employees.AddItem(); break;
        //    case MenuHelpers.List: employees.ListEmployees(); break;
        //    case MenuHelpers.Search: employees.SearchEmployee(); break;
        //    default: Console.WriteLine("\nEnter a valid command"); break;
        //}
        // }

        IUI ui = new FormsUi(employees);


    }
}