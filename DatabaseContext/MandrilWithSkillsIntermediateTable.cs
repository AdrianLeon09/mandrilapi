using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MandrilAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.DatabaseContext;
//Creacion de una relacion explicita muchos a muchos con EF
public class MandrilWithSkillsIntermediateTable
{
    //Se define la PK(Primary Key) de la clase actual
    
    //Por convencion debe tener el mismo nombre con id al final
   // [Key]
   // public int MandrilHabilidadesid {get; set;}

    //Se especifica la llave foranea de la tabla que se necesita como relacion
    //Por convencion seria mandrilId(que es igual a tabla mandril columna id)
    [ForeignKey(nameof(Mandrilid))] 
    
    //La PK es de tipo int y se llama MandrilId(Se usa la variable actual para identificar a la anterior mencionada)
    public int Mandrilid {get; set;}
    
    //Se crea un objeto de referencia para poder manejar los objetos mediante la relacion de las tablas que hace EF
    //Automaticamente.
    public   Mandril Mandril { get; set; }
    
//Se especifica la llave foranea de la tabla que se necesita como relacion
    [ForeignKey(nameof(Habilidadid))]
  
    //La PK es de tipo int y se llama MandrilId(Se usa la variable actual para identificar a la anterior mencionada)
    public int Habilidadid {get; set;}
    //Se crea un objeto de referencia para poder acceder a la base de datos padre desde el codigo
    public  Skill Habilidad {get; set;}
    
    public int  PotenciaMH { get; set; }

    public static bool MandrilIsValid(MandrilWithSkillsIntermediateTable mandrilObj)
    {
        if (mandrilObj != null  && mandrilObj.Mandril != null && mandrilObj.Habilidad != null && mandrilObj.PotenciaMH <= 0)
        {
            return true;

        }else {return false;}
    }
}