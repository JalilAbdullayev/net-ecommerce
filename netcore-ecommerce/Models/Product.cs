using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_ecommerce.Models;

public class Product {
    [Key]
    public int ProductId {get;set;}

    [Display(Name = "Name")]
    public string? Name {get;set;} = string.Empty;

    [Display(Name = "Code")]
    public int? Code {get;set;}

    [Display(Name = "Description")]
    public string? Description {get;set;} = string.Empty;

    [Display(Name = "Picture")]
    public string? Picture {get;set;}

    [Display(Name = "Price")]
    public int? Price {get;set;}

    [Display(Name = "Category")]
    public int? CategoryId {get;set;}

    virtual public Category? Category {get;set;}

    [NotMapped]
    public IFormFile? ImageUpload {get;set;}
}