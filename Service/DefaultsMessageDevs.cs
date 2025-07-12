namespace MandrilAPI.Service
{
    public class DefaultsMessageDevs
    {
        public const string DatabaseNull = "La informacion no se ha encontrado en la base de datos.";
        public const string ObjectIsNull = "El objeto devuelto {EntityType} es null.";
        public const string EntryInvalid = "Datos invalidos verifique que los campos no esten vacios o tengan minimo 3 caracteres.";

        public const string NotFoundMandril = "El objeto de tipo Mandril con ID {EntityID} no se ha encontrado o no existe.";
        public const string NotFoundSkill = "La Habilidad con ID {EntityID} no se ha encontrado o no existe.";
        public const string NotFoundRelationSkill = "No se ha encontrado una habilidad {targetSkillId} relacionada al mandril {targetMandrilId} especificado.";
        public const string DeleteFailed = "No se han podido eliminar los datos. verifique que la informacion exista o sea accesible.";
        public const string DeleteSucceeded = "Los datos han sido eliminados exitosamente.";

        public const string relationHasBeenCreated = "Se ha generado una relacion entre Skill ID : {EntitySkillID}. y Mandril ID {EntityMandrilID} \n" +
            "La potencia de la habilidad para el mandril se ha establecido en los valores por defecto = {PotenciaMH}";
        public const string relationNotCreated_EntityNotFound = "No se ha podido generar una relacion entre Mandril ID : {EntityMandril} y Skill ID : {EntitySkill}. \n" +
            "Uno o mas elementos no existen en la base de datos.  ";

        public const string UpdateSkillSucceeded = "Se ha actualizado la habilidad con ID {EntitySkillID} exitosamente.";
        public const string UpdateMandrilSucceeded = "Se ha actualizado el mandril con ID {EntityMandrilID} exitosamente.";
        public const string UpdateFailed = "No se ha podido actualizar el objeto con ID {EntityID}. Verifique que la informacion exista. O los tipos de datos coincida.";
        public const string UpdateRelationFailed = "No se ha podido actualizar la potencia de la habilidad {EntitySkillID} en el mandril {EntityMandrilID}. Verifique que la informacion exista. O los tipos de datos coincida.";
        public const string UpdatePowerSucceeded = "Se ha actualizado la potencia de la habilidad {EntitySkillID} en el mandril {EntityMandrilID} exitosamente. El nuevo valor es {EntityPower}";

         public const string MandrilAddedSuccessfully = "El mandril se ha creado correctamente.";
        public const string NotCreatedMandril = "No se ha podido crear el mandril en la base de datos. verifique si los datos cumplen los requisitos";
    }

}
