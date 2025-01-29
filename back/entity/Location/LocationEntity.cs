using System.ComponentModel.DataAnnotations;
namespace meero.entity;
public class LocationEntity {
    [Key]
    public int Id {get;set;}
    public required string  Address {get;set;}
    public required string  City {get;set;}
    public required string  Country {get;set;}
    public string?  LocationImage {get;set;}
    public string?  GoogleFrame {get;set;}
    public bool IsVirtual {get;set;}
}