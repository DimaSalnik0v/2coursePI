using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.Domain
{
    public class JobTitles
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string name_job_title { get; set; }
    }
}
