using System;
using System.ComponentModel.DataAnnotations;
namespace ServiceManagerApp3.Models
{
    public class ServiceRequest
    {
        [Key]//Уникальный идентификатор
        public int Id { get; set; }

        [Required(ErrorMessage ="Имя клиента обязтально")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Тип услуги обязателен")]
        [StringLength(100)]
        public string ServiceType { get; set; }

        [Required(ErrorMessage ="Описание обязательно")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateTime {  get; set; }= DateTime.Now; //Автоматическое создание 
    }
}
