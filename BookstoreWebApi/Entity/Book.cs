using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreWebApi.Entity;

public class Book {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID {get;set;}
    [Required]
    public string Title { get; set; }
    [Required]
    public int GenreID {get;set;}
    [Required]
    public int PageCount { get; set; }
    [Required]
    public DateTime PublishDate { get; set; }
    
}