
using System.Diagnostics;

namespace TemplateEngine;

public class TemplateEngine
{

    private string template;

    private Dictionary<string, string> variables = new Dictionary<string, string>();
    public string Evaluate()
    {
        var fullname = this.template;
        foreach (var variable in variables)
        {
            fullname = fullname.Replace("{" + variable.Key + "}", variable.Value);
        }

        return fullname;
    }

    public void SetTemplate(string template)
    {
        this.template = template;
    }

    public void SetVariable(string name, string value)
    { 
        variables.Add(name, value);
    }
}
