using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreWebApi.Entity
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;


    }
}