using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models;
//Creacion de una relacion explicita muchos a muchos con EF
public class MandrilHabilidades
{
    //Se define la PK(Primary Key) de la clase actual
    
    //Por convencion debe tener el mismo nombre con id al final
    [Key]
    public int MandrilHabilidadesid {get; set;}

    //Se especifica la llave foranea de la tabla que se necesita como relacion
    //Por convencion seria mandrilId(que es igual a tabla mandril columna id)
    [ForeignKey(nameof(Mandrilid))] 
    
    //La PK es de tipo int y se llama MandrilId(Se usa la variable actual para identificar a la anterior mencionada)
    public int Mandrilid {get; set;}
    
    //Se crea un objeto de referencia para poder manejar los objetos de manera relacionada
    //Automaticamente.
    public   Mandril Mandril { get; set; }
    
    //Se especifica la llave foranea de la tabla que se necesita como relacion
    [ForeignKey(nameof(Habilidadid))]
  
    //La PK es de tipo int y se llama MandrilId(Se usa la variable actual para identificar a la anterior mencionada)
    public int Habilidadid {get; set;}
    //Se crea un objeto de referencia para poder manejar los objetos de manera relacionada
    public  Habilidad Habilidad {get; set;}
    
}