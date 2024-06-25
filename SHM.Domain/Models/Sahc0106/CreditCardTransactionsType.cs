using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Models.Sahc0106 {

    [Table("CreditCardTransactionsType", Schema = "Sahc0106")]
    public class CreditCardTransactionsType : StandardColumns {


        /// <summary>
        /// Llave de la tabla CreditCardTransactionsType
        /// </summary>
        [Key]
        public Guid CreditCardTransactionsTypeKey { get; set; }

        /// <summary>
        /// Campo para una descripción de la transaccion.
        /// </summary>
        [Column(TypeName = "NVARCHAR(50)")]
        public string? Description { get; set; }

        /// <summary>
        /// Campo para indicar el status de la transacción.
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Campo para registar el código del tipo de transacción.
        /// </summary>
        [Column(TypeName = "NVARCHAR(50)")]
        public string? Code { get; set; }

        /// <summary>
        /// Campo para registrar una breve descripcion del tipo de transaccion.
        /// </summary>
        [Column(TypeName = "NVARCHAR(250)")]
        public string? Details { get; set; }

        /// <summary>
        /// Campo que indica si el tipo de transaccion esta relacionado a una cuenta contable
        /// </summary>
        [Column(TypeName = "NVARCHAR(50)")]
        public string? FinantialAccount { get; set; }

        /// <summary>
        /// Campo para registrar el tipo de ajuste, si es de tipo
        /// Debit o Credit
        /// </summary>
        [Column(TypeName = "NVARCHAR(10)")]
        public string? AdjusmentType { get; set; }

        /// <summary>
        /// Permite indicar un código externo.
        /// </summary>
        [Column(TypeName = "NVARCHAR(50)")]
        public string? ExternalCode1 { get; set; }

        /// <summary>
        /// Permite indicar un segundo código externo.
        /// </summary>
        [Column(TypeName = "NVARCHAR(50)")]
        public string? ExternalCode2 { get; set; }


    }
}


