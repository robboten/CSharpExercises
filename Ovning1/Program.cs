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
        ISerialize serializable = new EmployeesSerialize();
        ConsoleUi ui = new();
        Payroll employees = new(serializable);

        //postgresql.dosql();
        while (true)
         {
            ui.Print($"Enter a command:\n{MenuHelpers.Add} to add new \t{MenuHelpers.List} to list all \t{MenuHelpers.Search} to search for employee \t{MenuHelpers.Quit} to quit");
            char command = Console.ReadKey().KeyChar;
            switch (command)
            {
                case MenuHelpers.Quit: ui.Print("\nquitting..."); return;
                case MenuHelpers.Add: employees.AddItem(); break;
                case MenuHelpers.List: employees.ListEmployees(); break;
                case MenuHelpers.Search: employees.SearchEmployee(); break;
                default: ui.Print("\nEnter a valid command"); break;
            }
        }

        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //IUI ui = new WinFormsUi(employees);
    }
}