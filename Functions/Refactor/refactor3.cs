public class EmployeeDatabase 
{
    private readonly IDbConnection _db;

    public EmployeeDatabase(IDbConnection dbConnection) 
    {
        _db = dbConnection;
    }

    public Employee GetEmployee(int id) 
    {

        Employee employee =  _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id", 
            new { Id = id });

        return employee;
    }

    public void SaveEmployee(Employee emp) 
    {
        _db.Execute(
            "UPDATE Employees SET Name = @Name WHERE Id = @Id", 
            new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id) 
    {

        _db.Execute(
            "DELETE FROM Employees WHERE Id = @Id", 
            new { Id = id });
    }
}

public class EmployeeService 
{
    private readonly EmployeeDatabase employeeDatabase;
    const int charimanID = 1;
    const int nameLength = 150;
    const int reservedEmployeeID = 50

    public EmployeeService(EmployeeDatabase repo) 
    {
        employeeDatabase = repo;
    }

    public Employee GetEmployee(int id) 
    {
        ValidateReservedEmployee(id)
        return employeeDatabase.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp) 
    {
        if (emp.Name.Length > nameLength)
            throw new InvalidDataException("Name too long");

        employeeDatabase.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id) 
    {
        if (emp.ID == charimanID)
            throw new InvalidDataException("Chariman cant be removed ");

        employeeDatabase.DeleteEmployee(id);
    }

    private ValidateReservedEmployee (int id){
        
            if (id < reservedEmployeeID)
            throw new InvalidDataException("Employee ID starts from 50 , 1 to 49 is reserved for promoters , investors etc . Data cant be shared in HRMS due to Security issues ");
    }
}
