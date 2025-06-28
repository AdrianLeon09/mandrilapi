namespace MandrilAPI.Service
{
    public class DefaultsMessageDevs
    {
        public static string DatabaseNull = "La informacion no se ha encontrado en la base de datos.";
        public static string ObjectIsNull = "El objeto devuelto {EntityType} es null.";

        public static string NotFoundMandril = "El objeto de tipo Mandril con ID {EntityID} no se ha encontrado o no existe.";
        public static string NotFoundSkill = "La Habilidad con ID {EntityID} no se ha encontrado o no existe.";
        public static string NotFoundRelationSkill = "No se ha encontrado una habilidad {targetSkillId} relacionada al mandril {targetMandrilId} especificado.";
        public static string DeleteFailed = "No se han podido eliminar los datos. verifique que la informacion exista o sea accesible.";
        public static string DeleteSucceeded = "Los datos han sido eliminados exitosamente.";

        
        public static string relationHasBeenCreated = "Se ha generado una relacion entre Mandril ID : {EntityMandril} y Skill ID : {EntitySkill}. \n" +
            "La potencia de la habilidad para el mandril es : {PotenciaMH}";
        public static string relationNotCreated_EntityNotFound = "No se ha podido generar una relacion entre Mandril ID : {EntityMandril} y Skill ID : {EntitySkill}. \n" +
            "Uno o mas elementos no existen en la base de datos.  ";
        

    }
}
