public class PrinterDriver
{
    private IInputDevice inputDevice;
    private Printer printer;

    public PrinterDriver(IInputDevice inputDevice, Printer printer){
        this.inputDevice = inputDevice;
        this.printer = printer;
    }


    public void Print(){
        string page = inputDevice.readPage();
        while(!inputDevice.IsEndOfFile(page)){
            printer.Print(page);
            page = inputDevice.readPage();
        }
    }
}


public interface IInputDevice
{
    bool IsEndOfFile(string text);
    string readPage();
}

public class file : IInputDevice
{
    public bool IsEndOfFile(string text){
        return IsEOF(text);
    }
    public string readPage(){
        //read the page
    }

    private bool IsEOF(string text){
        //check if the page is the last page
    }
}

public class Scanner : IInputDevice
{
    public bool IsEndOfFile(string text){
        //check if the page is the last page
    }
    public string readPage(){
        readNextPage();
    }

    private string readNextPage()
    {
        //read the next page
    }
}

public class Mobile : IInputDevice
{
    public bool IsEndOfFile(string text){
        //check if the page is the last page
    }
    public string readPage(){
        //read the page
    }
}

public class Fax : IInputDevice
{
    public bool IsEndOfFile(string text){
        //check if the page is the last page
    }
    public string readPage(){
        //read the page
    }
}
