using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Helper;



public class ElasticPost
{
    public bool _extract_binary_content { get; set; } = true;
    public bool _reduce_whitespace { get; set; } = true;
    public bool _run_ml_inference { get; set; } = true;
    public string title { get; set; }
    public DateTime timestamp { get; set; }
    public string level { get; set; }
    public string addOnName { get; set; }
    public string addOnVersion { get; set; }
    public string message { get; set; }
    public string exception { get; set; }
    public string azureFunctionName { get; set; }
}

