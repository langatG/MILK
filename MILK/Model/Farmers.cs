using System.ComponentModel.DataAnnotations;

namespace MILK.Model
{
    public class Farmer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string MemberNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int IDNo { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public Boolean Active { get; set; }
        public string Village { get; set; }
        public string Location { get; set; }
        public string Division { get; set; }
        public string Payment { get; set; }
        public string Bankcode { get; set; }
        public string Bankname { get; set; }
        public string Bankacc { get; set; }
        public DateTime Createddate { get; set; } = DateTime.Now;
        public string photo { get; set; }


    }
}
