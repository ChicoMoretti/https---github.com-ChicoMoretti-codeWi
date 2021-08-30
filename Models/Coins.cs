using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplicationAPI.Models
{
    public class Coins
    {

        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [JsonPropertyName("moeda")]
        [MaxLength(3)]
        [MinLength(0)]
        [Required]
        public string Coin { get; set; }
        [JsonPropertyName("data_inicio")]
        [Required]
        public DateTime DateStart { get; set; }
        [JsonPropertyName("data_fim")]
        [Required]
        public DateTime DateEnd { get; set; }
        public string Message { get; set; }
    }
}
