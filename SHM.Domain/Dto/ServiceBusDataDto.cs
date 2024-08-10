using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Dto;



public class ServiceBusDTO
{

    [Required]
    public Guid MessageId { get; set; }

    public string Action { get; set; }

    public string Api { get; set; }

    public DateTime? Timestamp { get; set; }

    public string Key { get; set; }

    public string Method { get; set; }

}



